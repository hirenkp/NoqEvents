using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Events.Models;

[Table("Country")]
public partial class Country
{
    [Key]
    public short Id { get; set; }

    [StringLength(3)]
    public string CountryCode { get; set; } = null!;

    [Column("Country")]
    [StringLength(50)]
    public string Country1 { get; set; } = null!;
}
