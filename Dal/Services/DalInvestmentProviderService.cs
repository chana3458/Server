using Dal.Api;
using Dal.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Services
{
    public class DalInvestmentProviderService : IdalInvestmentProvider
    {

        dbcontext dbcontext;

        IdalInvestmentProvider investmentProvider;


        public DalInvestmentProviderService(dbcontext data)
        {

            dbcontext = data;

        }
        public async Task create(InvestmentProvider item)
        {
            dbcontext.InvestmentProviders.Add(item);
           await dbcontext.SaveChangesAsync();
        }

        public async Task Delete(string id)
        {
            InvestmentProvider? cust =await dbcontext.InvestmentProviders.FindAsync(id);
            dbcontext.InvestmentProviders.Remove(cust);
          await  dbcontext.SaveChangesAsync();
        }

        public async Task<List<InvestmentProvider>> GetAll()=>await dbcontext.InvestmentProviders .ToListAsync();


        public async Task update(InvestmentProvider item)
        {
            InvestmentProvider newInvestmentProvider = await   dbcontext.InvestmentProviders.FindAsync(item.Id);
            newInvestmentProvider.Id = item.Id;
            newInvestmentProvider.PhoneNumber = item.PhoneNumber;
            newInvestmentProvider.Name = item.Name;
            newInvestmentProvider.Address = item.Address;

          await  dbcontext.SaveChangesAsync();
        }
    }
}
