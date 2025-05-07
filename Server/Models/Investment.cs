using System;
using System.Collections.Generic;

namespace Server.Models;

public partial class Investment
{
    public string Id { get; set; } = null!;

    public string? Locatoin { get; set; }

    public string? Price { get; set; }

    public string? Description { get; set; }

    public string? Image { get; set; }

    public string? Ipid { get; set; }

    public int? RiskLevel { get; set; }

    public int? Range { get; set; }

    public virtual InvestmentProvider? Ip { get; set; }
}
