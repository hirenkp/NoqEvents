using System;
using System.Collections.Generic;

namespace Events.Entities;

public partial class OperatorType
{
    public short Id { get; set; }

    public string Type { get; set; } = null!;
}
