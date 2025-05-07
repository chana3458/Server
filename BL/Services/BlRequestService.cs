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

        
        public async Task<BlRequest> castToBl(RequestDetail request)
        {
            BlRequest newReq = new BlRequest();
            newReq.Id = request.Id;
            newReq.RiskLevel = request.RiskLevel;
            newReq.Budget = request.Budget;
            newReq.GotOffer = request.GotOffer;
            newReq.PhoneNumber = dal.Customer.GetCustomerById(request.Id).Result.PhoneNumber;
            newReq.Name = dal.Customer.GetCustomerById(request.Id).Result.Name;

            return newReq;

        }
        public async Task<RequestDetail> castToDal(BlRequest request)
        {
            RequestDetail newReq = new RequestDetail();
            newReq.Id = request.Id;
            newReq.RiskLevel = request.RiskLevel;
            newReq.Budget = request.Budget;
            newReq.GotOffer = request.GotOffer;
            

            return newReq;

        }


        public async Task create(BlRequest request)
        {

           RequestDetail newReq=castToDal(request).Result;


            dal.RequestDetails.create(newReq);}
       

        public async Task deleteById(string id)
        {
            dal.RequestDetails.Delete(id);
        }

        public async Task< List<BlRequest>> GetAll()
        {

           
            var rList = dal.RequestDetails.GetAll();

            List<BlRequest> list = new List<BlRequest>();
            
            rList.Result.ForEach(p => list.Add(castToBl(p).Result  ));
            return list;
        }

        public async Task update(BlRequest request)
        {
            RequestDetail newRequest = castToDal(request).Result    ;
            dal.RequestDetails.update(newRequest);
        }
       public async Task deleteInt(int id){
            dal.RequestDetails.DeleteInt(id);
        }

       
    }
}
