using System;
using System.Collections.Generic;

namespace Server.Models;

public partial class InvestmentProvider
{
    public string Id { get; set; } = null!;

    public string? Name { get; set; }

    public string? PhoneNumber { get; set; }

    public string? Address { get; set; }

    public virtual ICollection<Investment> Investments { get; set; } = new List<Investment>();
}
