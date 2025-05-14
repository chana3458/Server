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
    public class BlInvestmentService : IblInvestment
    {


        IDal dal;
        public BlInvestmentService(IDal dal)
        {

            this.dal = dal;

        }


         public async  Task<Investment> castToDal(BlInvestment investment)
        {
            Investment newInvestment = new Investment();

            newInvestment.Id = investment.Id;
            newInvestment.Description = investment.Description;
            newInvestment.Images = investment.Images;
            newInvestment.MinInvestment = investment.MinInvestment;
            newInvestment.RiskLevel = investment.RiskLevel;
             newInvestment.Title= investment.Title;  
             newInvestment.Roi = investment.Roi;
            newInvestment.Price = investment.Price;
            newInvestment.Ipid = investment.Ipid;
            newInvestment.Location = investment.Location;
            newInvestment.Description = investment.Description;
            newInvestment.Features = investment.Features;
            newInvestment.Term = investment.Term;
            newInvestment.Type = investment.Type;
            newInvestment.Ipid = investment.Ipid;
            newInvestment.InvestmentProgress = investment.InvestmentProgress; 
            newInvestment.InvestorCount = investment.InvestorCount;
            newInvestment.ExpectedCompletion = investment.ExpectedCompletion;

            return newInvestment; 
        }

        public async Task<BlInvestment> castToBl(Investment investment)
        {
            BlInvestment newInvestment = new BlInvestment();

            newInvestment.Id = investment.Id;
            newInvestment.Description = investment.Description;
            newInvestment.Images = investment.Images;
            newInvestment.MinInvestment = investment.MinInvestment;
            newInvestment.RiskLevel = investment.RiskLevel;
            newInvestment.Title = investment.Title;
            newInvestment.Roi = investment.Roi;
            newInvestment.Price = investment.Price;
            newInvestment.Ipid = investment.Ipid;
            newInvestment.Location = investment.Location;
            newInvestment.Description = investment.Description;
            newInvestment.Features = investment.Features;
            newInvestment.Term = investment.Term;
            newInvestment.Type = investment.Type;
            newInvestment.Ipid = investment.Ipid;
            newInvestment.InvestmentProgress = investment.InvestmentProgress;
            newInvestment.InvestorCount = investment.InvestorCount;
            newInvestment.ExpectedCompletion = investment.ExpectedCompletion;

            return newInvestment;
        }


        public async Task create(BlInvestment investment)
        {
            Investment newInvestment =await castToDal(investment);
            
            await   dal.Investment.create(newInvestment);
        }

        public async Task DeleteById(string id)
        {
         await   dal.Investment.Delete(id);

        }

        public async Task<List<BlInvestment>> GetAll()
        {
            var iList =await dal.Investment.GetAll();

            List<BlInvestment> list = new List<BlInvestment>();


            foreach (var i in iList)
            {
                list.Add(await castToBl(i));
            }           
            return list;
        }

        

        public async Task<BlInvestment> getInvestmentByName(string name)
        {

            var i =await dal.Investment.GetInvestmentByName(name);

            BlInvestment nc =await castToBl(i);
            return nc;
        }

        public async Task update(BlInvestment investment)
        {  
          await  dal.Investment.update( await castToDal(investment));
        }

      
    }
}
