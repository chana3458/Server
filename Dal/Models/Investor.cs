using System;
using System.Collections.Generic;

namespace Dal.Models;

public partial class Investor
{
    public string Id { get; set; } = null!;

    public string? Name { get; set; }

    public string? PhoneNumber { get; set; }

    public string? Address { get; set; }
}
