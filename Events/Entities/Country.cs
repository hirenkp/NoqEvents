using System;
using System.Collections.Generic;

namespace Events.Entities;

public partial class Country
{
    public short Id { get; set; }

    public string CountryCode { get; set; } = null!;

    public string Country1 { get; set; } = null!;
}
