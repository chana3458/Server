using Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Models
{
    public class BlCustomer
    {

        public string Id { get; set; }

        public string? Name { get; set; }

        public string? PhoneNumber { get; set; }

        public string? Address { get; set; }
        public  ICollection<BlRequest>? RequestDetails { get; set; } = new List<BlRequest>();
    }
}
