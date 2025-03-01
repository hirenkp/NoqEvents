using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Events.Models;

[Table("NoqEvent")]
public partial class NoqEvent
{
    [Key]
    public int Id { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Reference { get; set; }

    [Column("Deal Name")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Deal_Name { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Event { get; set; }

    public short? CountryId { get; set; }

    public short? OperatorTypeId { get; set; }

    public short? OperatorId { get; set; }

    public short? DealStatusId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? StartDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? EndDate { get; set; }

    [Column( "Hardware Out Date", TypeName = "datetime")]
    public DateTime? Hardware_Out_Date { get; set; }

    [Column("Hardware In Date", TypeName = "datetime")]
    public DateTime? Hardware_In_Date { get; set; }
    
    [Column(TypeName = "datetime")]
    public DateTime? ExpectedReturnDate { get; set; }

    public short? ExpectedTerminals { get; set; }

    public short? ConfirmedTerminals { get; set; }

    public bool? IsArchived { get; set; }
}
