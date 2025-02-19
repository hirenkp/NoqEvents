namespace Events.Entities;

public partial class DailyTerminalAvailability
{
    public DateTime Date { get; set; }
    
    public int TotalAssigned { get; set; }
    
    public int TotalAvailable { get; set; }
}