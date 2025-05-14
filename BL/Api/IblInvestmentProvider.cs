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


        Task<List<BlInvestmentProvider>> GetAll();
        Task create(BlInvestmentProvider InvestmentProvider);
        Task DeleteById(String id);
        Task update(BlInvestmentProvider InvestmentProvider);
        Task<BlInvestmentProvider> getInvestmentProviderById(String id);
    }
}
