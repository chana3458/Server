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
    public class BlCustomerService : IblCustomer
    {
        IDal dal;
        IblRequest request;
        public BlCustomerService(IDal dal, IblRequest request) {
        
            this.dal = dal;
            this.request = request;

        }

        public void create(BlCustomer customer)
        {
            Customer newCustomer =new Customer();

            newCustomer.Id = customer.Id;
            newCustomer.Name = customer.Name;
            newCustomer.PhoneNumber = customer.PhoneNumber;
            newCustomer.Address = customer.Address;
            //newCustomer.RequestDetails = customer.RequestDetails;   
            dal.Customer.create(newCustomer);
            
        }

        public void DeleteById(String id)
        {
            
            dal.Customer.Delete(id);
        }
       
        public List<BlCustomer> GetAll()
        {
          var cList= dal.Customer.GetAll();

            List<BlCustomer> list= new List<BlCustomer>();

            cList.ForEach(p => list.Add(new BlCustomer()
            { Id = p.Id, Name = p.Name, PhoneNumber = p.PhoneNumber, Address = p.Address,

                //RequestDetails = (
                
                //p.RequestDetails.ToList().ForEach(r => p.RequestDetails.Add(new BlRequest()
                //{
                //    Id = r.Id,
                //    Budget = r.Budget,
                //    RiskLevel = r.RiskLevel,
                //    Range = r.Range,
                //    GotOffer = r.GotOffer,
                //    Name = p.Name,
                //    PhoneNumber = p.PhoneNumber
                    
                //}))
                //)


            }));
            return list;    
        }

        public BlCustomer getCustomerById(string id)
        {
            var cust= dal.Customer.GetCustomerById(id);
            if (cust == null)
                throw new NullReferenceException("aaa");

        BlCustomer nc = new BlCustomer() { Id = cust.Id, Name = cust.Name, PhoneNumber = cust.PhoneNumber, Address = cust.Address };
            return nc;
        }

        public void update(BlCustomer customer)
        {

            Customer newCustomer = new Customer();
            newCustomer.Id = customer.Id;
            newCustomer.Name = customer.Name;
            newCustomer.PhoneNumber = customer.PhoneNumber;
            newCustomer.Address = customer.Address;
            dal.Customer.update(newCustomer);
          
        }

        
    }
}
