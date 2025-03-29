using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Events.Models;

[Keyless]
public partial class vwEvent
{
    public int Id { get; set; }

    [StringLength(50)]
    public string? Reference { get; set; }

    [Column("Deal Name")]
    [StringLength(50)]
    public string? Deal_Name { get; set; }

    [Column("Event Name")]
    [StringLength(50)]
    public string? Event_Name { get; set; }

    [Column("Country Code")]
    [StringLength(3)]
    public string? Country_Code { get; set; }

    [StringLength(50)]
    public string? Country { get; set; }

    [Column("Operator Type")]
    [StringLength(50)]
    public string? Operator_Type { get; set; }

    [Column("Operator Name")]
    [StringLength(50)]
    public string? Operator_Name { get; set; }

    [Column("Deal Status")]
    [StringLength(50)]
    public string? Deal_Status { get; set; }

    [Column("Hardware Out Date", TypeName = "datetime")]
    public DateTime? Hardware_Out_Date { get; set; }

    [Column("Start Date", TypeName = "datetime(3)")]
    public DateTime? Start_Date { get; set; }

    [Column("End Date", TypeName = "datetime(3)")]
    public DateTime? End_Date { get; set; }

    [Column("Hardware In Date", TypeName = "datetime")]
    public DateTime? Hardware_In_Date { get; set; }

    [Column("Expected Return Date", TypeName = "datetime(3)")]
    public DateTime? Expected_Return_Date { get; set; }

    [Column("Expected Terminals")]
    public short? Expected_Terminals { get; set; }

    [Column("Confirmed Terminals")]
    public short? Confirmed_Terminals { get; set; }

    public bool? Archived { get; set; }

    public long? Days { get; set; }

    [StringLength(9)]
    public string? Month { get; set; }

    public int? Year { get; set; }
}
