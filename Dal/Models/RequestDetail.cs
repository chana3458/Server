using System;
using System.Collections.Generic;

namespace Dal.Models;

public partial class RequestDetail
{
    public string Id { get; set; } = null!;

    public int? Budget { get; set; }

    public int? RiskLevel { get; set; }

    public int? Range { get; set; }

    public bool? GotOffer { get; set; }

    public int RequestId { get; set; }

       public virtual Customer IdNavigation { get; set; } = null!;
}
