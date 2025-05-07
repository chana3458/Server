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
    public class DalRequestService : IDalRequest
    {

        dbcontext dbcontext;

        //IDalRequest request;


        public DalRequestService(dbcontext data)
        {

            dbcontext = data;

        }
        public async Task create(RequestDetail item)
        {
            dbcontext.RequestDetails.Add(item);
            dbcontext.SaveChanges();
        }
        public async Task DeleteInt(int id)
        {
            RequestDetail? req = dbcontext.RequestDetails.Find(id);
            dbcontext.RequestDetails.Remove(req);
            dbcontext.SaveChanges();
        }
        public async Task Delete(string id)
        {
            RequestDetail? req = dbcontext.RequestDetails.Find(id);
            dbcontext.RequestDetails.Remove(req);
            dbcontext.SaveChanges();
        }


        

        public async Task<List<RequestDetail>> GetAll()=> dbcontext.RequestDetails.ToList();

        public async Task update(RequestDetail item)
        {
            RequestDetail newReq = dbcontext.RequestDetails.Find(item.Id);
            //newReq.Id = item.Id;
            newReq.RiskLevel = item.RiskLevel;
            newReq.Range = item.Range;
            newReq.Budget = item.Budget;
            newReq.GotOffer = item.GotOffer;    
            dbcontext.SaveChanges();
        }

        
    }
}
