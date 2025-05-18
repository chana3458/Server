using Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Models
{
    public class BlRequest
    {
        public string Id { get; set; } = null!;

        public int? Budget { get; set; }

        public int? RiskLevel { get; set; }

        public int? Range { get; set; }

        public bool? GotOffer { get; set; }

        public string? Name { get; set; }
        public string? PhoneNumber { get; set; }
        public int RequestId { get; set; }



    }
}
