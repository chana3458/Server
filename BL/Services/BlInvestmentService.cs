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
    public class BlInvestmentService : IblInvestment
    {


        IDal dal;
        public BlInvestmentService(IDal dal)
        {

            this.dal = dal;

        }

        public async Task create(BlInvestment investment)
        {
            Investment newInvestment = new Investment();
            newInvestment.Id = investment.Id;
            newInvestment.Ipid = investment.Ipid;
            newInvestment.RiskLevel = investment.RiskLevel;
            newInvestment.Range = investment.Range;
            newInvestment.Description = investment.Description;
            newInvestment.Image = investment.Image;
            newInvestment.Price = investment.Price;

            newInvestment.Locatoin = investment.Locatoin;

            dal.Investment.create(newInvestment);
        }

        public async Task DeleteById(string id)
        {
            dal.Investment.Delete(id);

        }

        public async Task<List<BlInvestment>> GetAll()
        {
            var iList = dal.Investment.GetAll();

            List<BlInvestment> list = new List<BlInvestment>();

            iList.Result.ForEach(i => list.Add(new BlInvestment()
            { Id = i.Id, Ipid = i.Ipid, Image = i.Image, Description = i.Description, Locatoin = i.Locatoin, Price = i.Price, Range = i.Range, RiskLevel = i.RiskLevel }));
            return list;
        }

        

        public async Task<BlInvestment> getInvestmentByName(string name)
        {

            var i = dal.Investment.GetInvestmentByName(name).Result;

            BlInvestment nc = new BlInvestment() { Id = i.Id, Ipid = i.Ipid, Image = i.Image, Description = i.Description, Locatoin = i.Locatoin, Price = i.Price, Range = i.Range, RiskLevel = i.RiskLevel };
            return nc;
        }

        public async Task update(BlInvestment investment)
        {
            Investment newInvestment = new Investment();
            newInvestment.Id = investment.Id;
            newInvestment.RiskLevel = investment.RiskLevel;
            newInvestment.Price = investment.Price;
            newInvestment.Description = investment.Description;
            newInvestment.Locatoin = investment.Locatoin;
            newInvestment.Ipid = newInvestment.Ipid;
            newInvestment.Range = newInvestment.Range;
            newInvestment.Image = newInvestment.Image;   
            dal.Investment.update(newInvestment);
        }

      
    }
}
