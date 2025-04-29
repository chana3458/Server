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
        public BlCustomerService(IDal dal) {
        
            this.dal = dal;

        }

        public void create(BlCustomer customer)
        {
            Customer newCustomer =new Customer();
            newCustomer.Id = customer.Id;
            newCustomer.Name = customer.Name;
            newCustomer.PhoneNumber = customer.PhoneNumber;
            newCustomer.Address = customer.Address;
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
            { Id = p.Id, Name = p.Name, PhoneNumber = p.PhoneNumber, Address = p.Address }));
            return list;    
        }

        public BlCustomer getCustomerById(string id)
        {
            var cust= dal.Customer.GetCustomerById(id);

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
