using System;
using System.Collections.Generic;

namespace Dal.Models;

public partial class Investment
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public string? Location { get; set; }

    public string? Type { get; set; }

    public int? Price { get; set; }

    public string? Ipid { get; set; }

    public int? RiskLevel { get; set; }

    public double? Roi { get; set; }

    public int? Term { get; set; }

    public int? MinInvestment { get; set; }

    public string? Description { get; set; }

    public string? Features { get; set; }

    public string? Images { get; set; }

    public double? InvestmentProgress { get; set; }

    public int? InvestorCount { get; set; }

    public DateTime? ExpectedCompletion { get; set; }

    public virtual InvestmentProvider? Ip { get; set; }
}
