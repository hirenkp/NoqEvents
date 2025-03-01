namespace Events.Models;

public partial class DailyTerminalAvailability
{
    public DateTime Date { get; set; }
    
    public int TotalExpectedAssigned { get; set; }
    
    public int TotalExpectedAvailable { get; set; }
    
    public int TotalConfirmedAssigned { get; set; }
    
    public int TotalConfirmedAvailable { get; set; }
    
}