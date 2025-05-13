using BL.Api;
using BL.Models;
using Dal.Api;
using Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services
{
    public class BlInvestmentProviderService : IblInvestmentProvider
    { 

         IDal dal;
    public BlInvestmentProviderService(IDal dal)
    {

        this.dal = dal;

    }
    
        public async Task create(BlInvestmentProvider InvestmentProvider)
        {
            InvestmentProvider newInvestmentProvider = new InvestmentProvider();
            newInvestmentProvider.Id = InvestmentProvider.Id;
            newInvestmentProvider.Name = InvestmentProvider.Name;
            newInvestmentProvider.PhoneNumber = InvestmentProvider.PhoneNumber;
            newInvestmentProvider.Address = InvestmentProvider.Address;
           await dal.InvestmentProvider.create(newInvestmentProvider);
        }

        public async Task DeleteById(string id)
        {
           await dal.InvestmentProvider.Delete(id);
        }

        public async Task<List<BlInvestmentProvider>> GetAll()
        {
            var cList =await dal.InvestmentProvider.GetAll() ;

            List<BlInvestmentProvider> list = new List<BlInvestmentProvider>();

            cList.ForEach(p => list.Add(new BlInvestmentProvider()
            { Id = p.Id, Name = p.Name, PhoneNumber = p.PhoneNumber, Address = p.Address }));
            return list;
        }

      

        public async Task update(BlInvestmentProvider InvestmentProvider)
        {
            InvestmentProvider newInvestmentProvider = new InvestmentProvider();
            newInvestmentProvider.Id = InvestmentProvider.Id;
            newInvestmentProvider.Name = InvestmentProvider.Name;
            newInvestmentProvider.PhoneNumber = InvestmentProvider.PhoneNumber;
            newInvestmentProvider.Address = InvestmentProvider.Address;
          await  dal.InvestmentProvider.update(newInvestmentProvider);
        }

       
    }
}
