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
            var customer = await dal.Customer.GetCustomerById(request.Id);
            if (customer != null)
            {
                newReq.PhoneNumber = customer.PhoneNumber;
                newReq.Name = customer.Name;
            }
            //newReq.PhoneNumber = (await dal.Customer.GetCustomerById(request.Id)).PhoneNumber;
            //newReq.Name = (await dal.Customer.GetCustomerById(request.Id)).Name;

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
           RequestDetail newReq=await castToDal(request);
           
                await dal.RequestDetails.create(newReq);
        }
       

        public async Task deleteById(int id)
        {
           await dal.RequestDetails.DeleteInt(id);
        }


        
        public async Task<List<BlRequest>> GetAll()
        {

            var rList = await dal.RequestDetails.GetAll();
            List<BlRequest> list = new List<BlRequest>();

            foreach (var p in rList)
            {
                BlRequest blRequest = await castToBl(p);
                list.Add(blRequest);
            }

            //var rList = await dal.RequestDetails.GetAll();

            
            return list;
        }


         

        public async Task update(BlRequest request)
        {
            RequestDetail newRequest =await castToDal(request) ;
           await dal.RequestDetails.update(newRequest);
        }
       public async Task deleteInt(int id){
          await  dal.RequestDetails.DeleteInt(id);
        }

        public Task deleteById(string id)
        {
            throw new NotImplementedException();
        }
    }
}
