using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Models
{
    public class BlInvestment
    {

        public string Id { get; set; } = null!;

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


    }
}
