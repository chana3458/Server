using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Models
{
    public class BlInvestment
    {

        public string Id { get; set; }

        public string? Locatoin { get; set; }

        public string? Price { get; set; }

        public string? Description { get; set; }

        public string? Image { get; set; }

        public string? Ipid { get; set; }

        public int? RiskLevel { get; set; }

        public int? Range { get; set; }

    }
}
