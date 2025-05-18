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
          await  dbcontext.SaveChangesAsync();
        }
        public async Task DeleteInt(int id)
        {
            RequestDetail? req = dbcontext.RequestDetails.Find(id);
            dbcontext.RequestDetails.Remove(req);
           await dbcontext.SaveChangesAsync();
        }


       
        public async Task Delete(string id)
        {
            RequestDetail? req =await dbcontext.RequestDetails.FindAsync(id);
            dbcontext.RequestDetails.Remove(req);
           await dbcontext.SaveChangesAsync();
        }


        

       public async Task<List<RequestDetail>> GetAll()=>await dbcontext.RequestDetails.ToListAsync();

    
        public async Task update(RequestDetail item)
        {
            RequestDetail newReq =await dbcontext.RequestDetails.FindAsync(item.RequestId );
            //newReq.Id = item.Id;
            newReq.RiskLevel = item.RiskLevel;
            newReq.Range = item.Range;
            newReq.Budget = item.Budget;
            newReq.GotOffer = item.GotOffer;    
           await dbcontext.SaveChangesAsync();
        }

    }
}
