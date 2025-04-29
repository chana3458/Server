using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Api
{
    public interface IBL
    {
        public IblInvestmentProvider InvestmentProvider { get; }
        public IblCustomer Customer { get;  }
        public IblRequest Request { get; }
        public IblInvestment Investment { get; }






    }
}
