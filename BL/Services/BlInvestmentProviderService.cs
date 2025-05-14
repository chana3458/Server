using Azure.Core;
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
        IblInvestment investments;
        public BlInvestmentProviderService(IDal dal)
    {

        this.dal = dal;

    }
        public async Task<InvestmentProvider> castToDal(BlInvestmentProvider Ip)
        {
            InvestmentProvider newIp = new InvestmentProvider();

            newIp.Id = Ip.Id;
            newIp.Name = Ip.Name;
            newIp.PhoneNumber = Ip.PhoneNumber;
            newIp.Address = Ip.Address;

            return newIp;
        }


        public async Task<BlInvestmentProvider> castToBl(InvestmentProvider Ip)
        {
            BlInvestmentProvider newIp = new BlInvestmentProvider();
            newIp.Id = Ip.Id;
            newIp.Name = Ip.Name;
            newIp.PhoneNumber = Ip.PhoneNumber;
            newIp.Address = Ip.Address;

            foreach (var x in Ip.Investments.ToList())
            {

                newIp.Investments.Add(await investments.castToBl(x));
            }

           
            return newIp;

        }

        




        public async Task create(BlInvestmentProvider InvestmentProvider)
        {
            InvestmentProvider newInvestmentProvider = await castToDal(InvestmentProvider);
           
            if (await getInvestmentProviderById(newInvestmentProvider.Id) != null)
                throw new Exception("id exsistes already");
            else await dal.InvestmentProvider.create(newInvestmentProvider);
          
        }

        public async Task<BlInvestmentProvider> getInvestmentProviderById(string id)
        {
            var Ip = await dal.InvestmentProvider.GetInvestmentProviderById(id);
            if (Ip == null)
                return null;
            //throw new NullReferenceException("cust not found");

            BlInvestmentProvider newIp = await castToBl(Ip);
            return newIp;
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
