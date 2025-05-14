using BL.Models;
using Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Api
{
    public interface IblInvestment
    {

        Task<List<BlInvestment>> GetAll();
        Task create(BlInvestment investment);
        Task DeleteById(String id);
        Task<BlInvestment> getInvestmentByName(String name);

        Task update(BlInvestment investment);
        Task<Investment> castToDal(BlInvestment investment);
        Task<BlInvestment> castToBl(Investment investment);
    }
}
