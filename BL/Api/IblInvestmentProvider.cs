using BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BL.Api
{
    public interface IblInvestmentProvider
    {


        List<BlInvestmentProvider> GetAll();
        void create(BlInvestmentProvider InvestmentProvider);
        void DeleteById(String id);
        void update(BlInvestmentProvider InvestmentProvider);
    }
}
