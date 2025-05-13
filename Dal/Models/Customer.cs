using System;
using System.Collections.Generic;

namespace Dal.Models;

public partial class Customer
{
    ///public readonly Customer Result;

    public string Id { get; set; } = null!;

    public string? Name { get; set; }

    public string? PhoneNumber { get; set; }

    public string? Address { get; set; }

    public virtual ICollection<RequestDetail> RequestDetails { get; set; } = new List<RequestDetail>();
}
