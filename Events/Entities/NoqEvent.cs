using System;
using System.Collections.Generic;

namespace Events.Entities;

public partial class NoqEvent
{
    public int Id { get; set; }

    public string? Reference { get; set; }

    public string? DealName { get; set; }

    public string? Event1 { get; set; }

    public short? CountryId { get; set; }

    public short? OperatorTypeId { get; set; }

    public short? OperatorId { get; set; }

    public short? DealStatusId { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public DateTime? ExpectedReturnDate { get; set; }

    public short? ExpectedTerminals { get; set; }
    
    public short? ConfirmedTerminals { get; set; }
    
    public bool? IsArchived { get; set; }
}
