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

        public async Task Delete(string id)
        {

            Investment? i =await dbcontext.Investments.FindAsync(id);
            dbcontext.Investments.Remove(i);
          await  dbcontext.SaveChangesAsync();
        }

        public  async Task<List<Investment>> GetAll() =>await dbcontext.Investments.ToListAsync();

        
            public async Task<Investment> GetInvestmentByName(string name) =>await dbcontext.Investments.FindAsync(name);

       
        public async Task update(Investment item)
        {

            Investment newIn =await dbcontext.Investments.FindAsync(item.Id);
            newIn.Id = item.Id;
            newIn.RiskLevel = item.RiskLevel;
            newIn.Range = item.Range;
            newIn.Price = item.Price;
            newIn.Description = item.Description;
            newIn.Image = item.Image;
            newIn.Ipid = item.Ipid;
            newIn.Locatoin = item.Locatoin;


           await dbcontext.SaveChangesAsync();
        }





    }
}
