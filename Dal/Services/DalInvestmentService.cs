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
    public class DalInvestmentService : IDalInvestment
    {

        dbcontext dbcontext;

        IdalInvestmentProvider investmentProvider;


        public DalInvestmentService(dbcontext data)
        {

            dbcontext = data;

        }

        public async Task create(Investment item)
        {
            dbcontext.Investments.Add(item);
          await  dbcontext.SaveChangesAsync();
        }

        public Task Delete(string item)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteInvestmentById(int id)
        {

            Investment? i = dbcontext.Investments.Find(id);
            dbcontext.Investments.Remove(i);
          await  dbcontext.SaveChangesAsync();
        }

        

        public  async Task<List<Investment>> GetAll() =>await dbcontext.Investments.ToListAsync();

        
            public async Task<Investment> GetInvestmentById(int id) =>await dbcontext.Investments.FindAsync(id);

        public async Task update(Investment investment)
        {

            Investment newIn =await dbcontext.Investments.FindAsync(investment.Id);
            newIn.Id = investment.Id;
            newIn.Description = investment.Description;
            newIn.Images = investment.Images;
            newIn.MinInvestment = investment.MinInvestment;
            newIn.RiskLevel = investment.RiskLevel;
            newIn.Title = investment.Title;
            newIn.Roi = investment.Roi;
            newIn.Price = investment.Price;
            newIn.Ipid = investment.Ipid;
            newIn.Location = investment.Location;
            newIn.Description = investment.Description;
            newIn.Features = investment.Features;
            newIn.Term = investment.Term;
            newIn.Type = investment.Type;
            newIn.Ipid = investment.Ipid;
            newIn.InvestmentProgress = investment.InvestmentProgress;
            newIn.InvestorCount = investment.InvestorCount;
            newIn.ExpectedCompletion = investment.ExpectedCompletion;

           await dbcontext.SaveChangesAsync();
        }





    }
}
