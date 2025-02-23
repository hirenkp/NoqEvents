namespace Events.Models;

public class TerminalAvailabilityParameters
{
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public int TotalTerminals { get; set; }
    public IEnumerable<DailyTerminalAvailability> DailyTerminalAvailability { get; set; } = Enumerable.Empty<DailyTerminalAvailability>();
}