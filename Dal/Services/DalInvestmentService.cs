﻿using Dal.Api;
using Dal.Models;
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
            dbcontext.SaveChanges();
        }

        public async Task Delete(string id)
        {

            Investment? i = dbcontext.Investments.Find(id);
            dbcontext.Investments.Remove(i);
            dbcontext.SaveChanges();
        }

        public  async Task<List<Investment>> GetAll() => dbcontext.Investments.ToList();

        
            public async Task<Investment> GetInvestmentByName(string name) => dbcontext.Investments.Find(name);

       
        public async Task update(Investment item)
        {

            Investment newIn = dbcontext.Investments.Find(item.Id);
            newIn.Id = item.Id;
            newIn.RiskLevel = item.RiskLevel;
            newIn.Range = item.Range;
            newIn.Price = item.Price;
            newIn.Description = item.Description;
            newIn.Image = item.Image;
            newIn.Ipid = item.Ipid;
            newIn.Locatoin = item.Locatoin;


            dbcontext.SaveChanges();
        }





    }
}
