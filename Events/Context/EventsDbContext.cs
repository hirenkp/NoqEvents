using System;
using System.Collections.Generic;
using Events.Models;
using Microsoft.EntityFrameworkCore;

namespace Events.Context;

public partial class EventsDbContext : DbContext
{
    public EventsDbContext(DbContextOptions<EventsDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Country> Countries { get; set; }
    public virtual DbSet<DealStatus> DealStatuses { get; set; }
    public virtual DbSet<NoqEvent> NoqEvents { get; set; }
    public virtual DbSet<Operator> Operators { get; set; }
    public virtual DbSet<OperatorType> OperatorTypes { get; set; }
    public virtual DbSet<vwEvent> vwEvents { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Country>(entity =>
        {
            entity.Property(e => e.CountryCode).IsFixedLength();
        });

        modelBuilder.Entity<NoqEvent>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Event");

            entity.Property(e => e.IsArchived).HasDefaultValue(false);
        });

        modelBuilder.Entity<vwEvent>(entity =>
        {
            entity.ToView("vwEvents");

            entity.Property(e => e.Country_Code).IsFixedLength();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}