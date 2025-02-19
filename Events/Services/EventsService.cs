using System.Data;
using Events.Context;
using Events.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Events.Services;

public class EventsService
{
    private readonly IDbContextFactory<EventsDbContext> _dbContextFactory;

    public EventsService(IDbContextFactory<EventsDbContext> dbContextFactory)
    {
        _dbContextFactory = dbContextFactory;
    }

    public async Task<IEnumerable<VwEvent>?> GetAllEvents()
    {
        using var db = await _dbContextFactory.CreateDbContextAsync();
        return await db.VwEvents.ToListAsync();
    }
    
    public async Task<Event?> GetEventById(int id)
    {
        using var db = await _dbContextFactory.CreateDbContextAsync();
        return await db.Events.FirstOrDefaultAsync(e => e.Id == id);
    }

    public async Task<Event?> UpdateEvent(int id, Event newEvent)
    {
        using var db = await _dbContextFactory.CreateDbContextAsync();
        var existingEvent = await db.Events.FirstOrDefaultAsync(e => e.Id == id);
        if (existingEvent != null)
        {
            existingEvent.Reference = newEvent.Reference;
            existingEvent.DealName = newEvent.DealName;
            existingEvent.Event1 = newEvent.Event1;
            existingEvent.CountryId = newEvent.CountryId;
            existingEvent.OperatorTypeId = newEvent.OperatorTypeId;
            existingEvent.OperatorId = newEvent.OperatorId;
            existingEvent.DealStatusId = newEvent.DealStatusId;
            existingEvent.EndDate = newEvent.EndDate;
            existingEvent.StartDate = newEvent.StartDate;
            existingEvent.ExpectedReturnDate = newEvent.ExpectedReturnDate;
            existingEvent.ExpectedTerminals = newEvent.ExpectedTerminals;
            //db.Update(existingEvent);
            await db.SaveChangesAsync();
            return existingEvent;
        }
        
        return null;
    }

    public async Task<Event> AddEvent(Event newEvent)
    {
        using var db = await _dbContextFactory.CreateDbContextAsync();
        db.Events.Add(newEvent);
        await db.SaveChangesAsync();
        return newEvent;
    }
    
    public async Task<IEnumerable<Country>> GetAllCountries()
    {
        using var db = await _dbContextFactory.CreateDbContextAsync();
        return await db.Countries.OrderBy(c => c.Country1).ToListAsync();
    }

    public async Task<IEnumerable<DealStatus>> GetAllDealStatuses()
    {
        using var db = await _dbContextFactory.CreateDbContextAsync();
        return await db.DealStatuses.OrderBy(ds => ds.Status).ToListAsync();
    }

    public async Task<IEnumerable<Operator>> GetAllOpearators()
    {
        using var db = await _dbContextFactory.CreateDbContextAsync();
        return await db.Operators.OrderBy(o => o.Name).ToListAsync();
    }

    public async Task<IEnumerable<OperatorType>> GetAllOpearatorTypes()
    {
        using var db = await _dbContextFactory.CreateDbContextAsync();
        return await db.OperatorTypes.OrderBy(ot => ot.Type).ToListAsync();
    }

    public async Task<IEnumerable<DailyTerminalAvailability>> GetDailyTerminalAvailabilitiesBetweenDates(DateTime? startDate, DateTime? endDate, int totalTerminals)
    {
        using var db = await _dbContextFactory.CreateDbContextAsync();
        //var results= await db.DailyTerminalAvailabilities.FromSqlInterpolated($"EXEC dbo.spGetTerminalAvailabilityByDateRange {startDate}, {endDate}, {totalTerminals}").ToListAsync();
        
        List<DailyTerminalAvailability> resultList = new List<DailyTerminalAvailability>();
        using (var command = db.Database.GetDbConnection().CreateCommand())
        {
            command.CommandText = "[dbo].[spGetTerminalAvailabilityByDateRange]";
            command.Parameters.Add(new SqlParameter("@startDate", startDate));
            command.Parameters.Add(new SqlParameter("@endDate", endDate));
            command.Parameters.Add(new SqlParameter("@totalTerminals", totalTerminals));
            command.CommandType = CommandType.StoredProcedure;
            
            db.Database.OpenConnection();

            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    try
                    {
                        resultList.Add(new DailyTerminalAvailability()
                        {
                            Date = reader.GetDateTime("Date"),
                            TotalAssigned = reader.GetInt32("No. Terminals Assigned"),
                            TotalAvailable = reader.GetInt32("No. Terminals Available"),
                        });
                    }
                    catch (Exception ex)
                    {
                        string msg = ex.Message;
                    }
                }
            }
        }        
        return resultList;

        //var results= await db.Set<DailyTerminalAvailability>().FromSqlRaw("EXEC dbo.spGetTerminalAvailabilityByDateRange @StartDate, @EndDate, @TotalTerminals", new SqlParameter("@StartDate", startDate), new SqlParameter("@EndDate", endDate), new SqlParameter("@TotalTerminal", totalTerminals)).ToListAsync();
        //var results= db.Database.SqlQueryRaw<DailyTerminalAvailability>("EXEC dbo.spGetTerminalAvailabilityByDateRange @StartDate, @EndDate, @TotalTerminals", startDate, endDate, TotalTerminals).ToList();
    }
}