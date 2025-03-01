using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Events.Models;

[Table("Operator")]
public partial class Operator
{
    [Key]
    public short Id { get; set; }

    [StringLength(50)]
    public string Name { get; set; } = null!;
}
