using BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Api
{
    public interface IblInvestment
    {

        List<BlInvestment> GetAll();
        void create(BlInvestment investment);
        void DeleteById(String id);
        BlInvestment getInvestmentByName(String name);

        void update(BlInvestment investment);
    }
}
