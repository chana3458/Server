using Dal.Api;
using Dal.Models;
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
        public void create(InvestmentProvider item)
        {
            dbcontext.InvestmentProviders.Add(item);
            dbcontext.SaveChanges();
        }

        public void Delete(string id)
        {
            InvestmentProvider? cust = dbcontext.InvestmentProviders.Find(id);
            dbcontext.InvestmentProviders.Remove(cust);
            dbcontext.SaveChanges();
        }

        public List<InvestmentProvider> GetAll()=> dbcontext.InvestmentProviders .ToList();


        public void update(InvestmentProvider item)
        {
            InvestmentProvider newInvestmentProvider = dbcontext.InvestmentProviders.Find(item.Id);
            newInvestmentProvider.Id = item.Id;
            newInvestmentProvider.PhoneNumber = item.PhoneNumber;
            newInvestmentProvider.Name = item.Name;
            newInvestmentProvider.Address = item.Address;

            dbcontext.SaveChanges();
        }
    }
}
