using Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Api
{
    public interface IDalInvestment: ICrud<Investment>
    {
        Task<Investment> GetInvestmentById(int id);
        Task DeleteInvestmentById(int id);

    }
}
