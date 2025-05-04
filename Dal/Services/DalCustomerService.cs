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
    public class DalCustomerService : IDalCustomer
    {
        dbcontext dbcontext;

        //IDalCustomer customer;


        public DalCustomerService(dbcontext data) {
        
            dbcontext = data;    
        
        }

        public void create(Customer item)
        {
            dbcontext.Customers.Add(item);
            dbcontext.SaveChanges();
        }

        public void Delete(String id)
        {
           Customer? cust= dbcontext.Customers.Find(id);
            dbcontext.Customers.Remove(cust);
            dbcontext.SaveChanges();
        }


    
           
            //.Include(x => x.RequestDetails).
        
        public List<Customer> GetAll()=>dbcontext.Customers.ToList();

        public void update(Customer item) {

            Customer newCust = dbcontext.Customers.Find(item.Id);
            newCust.Id = item.Id;
            newCust.PhoneNumber = item.PhoneNumber;
            newCust.Name = item.Name;
            newCust.Address= item.Address;  
         
            dbcontext.SaveChanges();
        }

        public Customer GetCustomerById(string id)=> dbcontext.Customers.Find(id);
    }
}
