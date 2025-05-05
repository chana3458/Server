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
        public Customer castToDal(BlCustomer customer)
        {


            Customer newCustomer = new Customer();

            newCustomer.Id = customer.Id;
            newCustomer.Name = customer.Name;
            newCustomer.PhoneNumber = customer.PhoneNumber;
            newCustomer.Address = customer.Address;
           
            return newCustomer; 
        }


        public BlCustomer castToBl(Customer customer)
        {
            BlCustomer newCustomer = new BlCustomer();


            newCustomer. Id = customer.Id;
            newCustomer.Name = customer.Name;
            newCustomer. PhoneNumber = customer.PhoneNumber;
            newCustomer.Address = customer.Address;
            //cList.ForEach(p => list.Add(castToBl(p)));
            customer.RequestDetails.ToList().ForEach(x => newCustomer.RequestDetails.Add(request.castToBl(x)));
            
            return newCustomer;

        }

        public void create(BlCustomer customer)
        {
            Customer newCustomer = castToDal(customer);
            if (getCustomerById(newCustomer.Id) != null)
                throw new Exception("id exsistes");
           else  dal.Customer.create(newCustomer);
            
        }

        public void DeleteById(String id)
        {
            
            dal.Customer.Delete(id);
        }
       
        public List<BlCustomer> GetAll()
        {
          var cList= dal.Customer.GetAll();

            List<BlCustomer> list= new List<BlCustomer>();

            cList.ForEach(p => list.Add(castToBl(p)));
           

            
            return list;    
        }

        public BlCustomer getCustomerById(string id)
        {
            var cust= dal.Customer.GetCustomerById(id);
            if (cust == null)
                throw new NullReferenceException("aaa");

        BlCustomer nc = castToBl(cust);
            return nc;
        }

        public void update(BlCustomer customer)
        {
            Customer newCustomer = castToDal(customer);
            dal.Customer.update(newCustomer);
          
        }

        
    }
}
