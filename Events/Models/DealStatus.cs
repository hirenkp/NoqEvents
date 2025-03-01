using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Events.Models;

[Table("DealStatus")]
public partial class DealStatus
{
    [Key]
    public short Id { get; set; }

    [StringLength(50)]
    public string Status { get; set; } = null!;
}
