using BL.Api;
using BL.Models;
using Dal.Api;
using Dal.Models;
using System;
using System.Collections;
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
        public async Task<Customer> castToDal(BlCustomer customer)
        {


            Customer newCustomer = new Customer();

            newCustomer.Id = customer.Id;
            newCustomer.Name = customer.Name;
            newCustomer.PhoneNumber = customer.PhoneNumber;
            newCustomer.Address = customer.Address;
           
            return newCustomer; 
        }


        public  async Task<BlCustomer> castToBl(Customer customer)
        {
            BlCustomer newCustomer = new BlCustomer();


            newCustomer. Id = customer.Id;
            newCustomer.Name = customer.Name;
            newCustomer. PhoneNumber = customer.PhoneNumber;
            newCustomer.Address = customer.Address;
            //cList.ForEach(p => list.Add(castToBl(p)));
            customer.RequestDetails.ToList().ForEach(x => newCustomer.RequestDetails.Add(request.castToBl(x).Result));
            
            return newCustomer;

        }

        public async Task create(BlCustomer customer)
        {
            Customer newCustomer = castToDal(customer).Result;
            if (getCustomerById(newCustomer.Id) != null)
                throw new Exception("id exsistes");
           else  dal.Customer.create(newCustomer);
            
        }

        public async Task DeleteById(String id)
        {
            
            dal.Customer.Delete(id);
        }
       
        public async  Task<List<BlCustomer>> GetAll()
        {
          var cList= dal.Customer.GetAll();

           List<BlCustomer> list= new List<BlCustomer>();

            cList.Result.ForEach(p => list.Add(castToBl(p).Result   ));
           
                       
            return list;    
        }

        public  async Task<BlCustomer> getCustomerById(string id)
        {
            var cust= dal.Customer.GetCustomerById(id).Result;
            if (cust == null)
                throw new NullReferenceException("cust not found");

        BlCustomer nc = castToBl(cust).Result;
            return nc;
        }

        public async Task update(BlCustomer customer)
        {
            Customer newCustomer = castToDal(customer).Result;
            dal.Customer.update(newCustomer);
          
        }

        
    }
}
