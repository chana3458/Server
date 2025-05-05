using Azure.Core;
using BL.Api;
using BL.Models;
using Dal.Api;
using Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services
{
    public class BlRequestService : IblRequest
    {


        IDal dal;
        public BlRequestService(IDal dal)
        {

            this.dal = dal;

        }

        
        public BlRequest castToBl(RequestDetail request)
        {
            BlRequest newReq = new BlRequest();
            newReq.Id = request.Id;
            newReq.RiskLevel = request.RiskLevel;
            newReq.Budget = request.Budget;
            newReq.GotOffer = request.GotOffer;
            newReq.PhoneNumber = dal.Customer.GetCustomerById(request.Id).PhoneNumber;
            newReq.Name = dal.Customer.GetCustomerById(request.Id).Name;

            return newReq;

        }
        public RequestDetail castToDal(BlRequest request)
        {
            RequestDetail newReq = new RequestDetail();
            newReq.Id = request.Id;
            newReq.RiskLevel = request.RiskLevel;
            newReq.Budget = request.Budget;
            newReq.GotOffer = request.GotOffer;
            

            return newReq;

        }


        public void create(BlRequest request)
        {

           RequestDetail newReq=castToDal(request);


            dal.RequestDetails.create(newReq);}
       

        public void deleteById(string id)
        {
            dal.RequestDetails.Delete(id);
        }

        public List<BlRequest> GetAll()
        {

           
            var rList = dal.RequestDetails.GetAll();

            List<BlRequest> list = new List<BlRequest>();
            
            rList.ForEach(p => list.Add(castToBl(p)));
            return list;
        }

        public void update(BlRequest request)
        {
            RequestDetail newRequest = castToDal(request);
            dal.RequestDetails.update(newRequest);
        }
       public void deleteInt(int id){
            dal.RequestDetails.DeleteInt(id);
        }

       
    }
}
