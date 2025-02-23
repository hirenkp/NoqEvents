using System;
using System.Collections.Generic;

namespace Events.Entities;

public partial class VwEvent
{
    public int Id { get; set; }
    public string? Reference { get; set; }
    public string? DealName { get; set; }
    public string? Event { get; set; }
    public string? Region { get; set; }
    public string? Country { get; set; }
    public string? TypeOfOperator { get; set; }
    public string? OperatorName { get; set; }
    public string? DealStatus { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public DateTime? ExpectedReturnDate { get; set; }
    public short? ExpectedTerminals { get; set; }
    public short?ConfirmedTerminals { get; set; }
    public int? Days { get; set; }
    public string? Month { get; set; }
    
    public bool? IsArchived { get; set; }
}
