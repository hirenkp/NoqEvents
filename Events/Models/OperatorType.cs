using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Events.Models;

[Table("OperatorType")]
public partial class OperatorType
{
    [Key]
    public short Id { get; set; }

    [StringLength(50)]
    public string Type { get; set; } = null!;
}
