using Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Models
{
    public class BlInvestmentProvider
    {

        public string Id { get; set; } = null!;

        public string? Name { get; set; }

        public string? PhoneNumber { get; set; }

        public string? Address { get; set; }


        public virtual ICollection<BlInvestment> Investments { get; set; } = new List<BlInvestment>();

    }
}
