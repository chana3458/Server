using Dal.Api;
using Dal.Models;
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
        public void create(RequestDetail item)
        {
            dbcontext.RequestDetails.Add(item);
            dbcontext.SaveChanges();
        }
        public void DeleteInt(int id)
        {
            RequestDetail? req = dbcontext.RequestDetails.Find(id);
            dbcontext.RequestDetails.Remove(req);
            dbcontext.SaveChanges();
        }
        public void Delete(string id)
        {
            RequestDetail? req = dbcontext.RequestDetails.Find(id);
            dbcontext.RequestDetails.Remove(req);
            dbcontext.SaveChanges();
        }

        


        public List<RequestDetail> GetAll()=> dbcontext.RequestDetails.ToList();

        public void update(RequestDetail item)
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
