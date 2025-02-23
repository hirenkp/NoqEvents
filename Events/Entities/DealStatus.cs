using System;
using System.Collections.Generic;

namespace Events.Entities;

public partial class DealStatus
{
    public short Id { get; set; }

    public string Status { get; set; } = null!;
}
