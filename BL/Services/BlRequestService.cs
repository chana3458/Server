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
    public class BlRequestService : IblRequest
    {


        IDal dal;
        public BlRequestService(IDal dal)
        {

            this.dal = dal;

        }
        public void create(BlRequest request)
        {
           
            RequestDetail newReq= new RequestDetail();
            newReq.Id = request.Id;
            newReq.RiskLevel = request.RiskLevel;
            newReq.Budget = request.Budget;
            newReq.GotOffer =false;
          
            dal.RequestDetails.create(newReq);}

        public void deleteById(string id)
        {
            dal.RequestDetails.Delete(id);
        }

        public List<BlRequest> GetAll()
        {

            //string name = dal.Customer.GetCustomerById(request.Id).Name;
            //string phoneNumber = dal.Customer.GetCustomerById(request.Id).PhoneNumber;
            var rList = dal.RequestDetails.GetAll();

            List<BlRequest> list = new List<BlRequest>();
            
            rList.ForEach(p => list.Add(new BlRequest()
            { Id = p.Id,   Budget = p.Budget, RiskLevel = p.RiskLevel, Range =p.Range, GotOffer=p.GotOffer, Name = dal.Customer.GetCustomerById(p.Id).Name ,PhoneNumber = dal.Customer.GetCustomerById(p.Id).PhoneNumber }));
            return list;
        }

        public void update(BlRequest request)
        {
            RequestDetail newRequest = new RequestDetail();
            newRequest.Id = request.Id;
            newRequest.Budget = request.Budget;
            newRequest.RiskLevel = request.RiskLevel;
            newRequest.Range = request.Range;
            newRequest.GotOffer = request.GotOffer;
            dal.RequestDetails.update(newRequest);
        }
       public void deleteInt(int id){
            dal.RequestDetails.DeleteInt(id);
        }
    }
}
