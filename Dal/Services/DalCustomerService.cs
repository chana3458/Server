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

        public async Task create(Customer item)
        {
            dbcontext.Customers.Add(item);
            dbcontext.SaveChanges();
        }

        public async Task Delete(String id)
        {
           Customer? cust= dbcontext.Customers.Find(id);
            dbcontext.Customers.Remove(cust);
            dbcontext.SaveChanges();
        }


    
           
            //.Include(x => x.RequestDetails).
        
        public async Task<List<Customer>> GetAll()=>dbcontext.Customers.Include(x=> x.RequestDetails).ToList();

        public async Task update(Customer item) {

            Customer? newCust = GetAll().Result.Find(x=> x.Id==item.Id);
            newCust.Id = item.Id;
            newCust.PhoneNumber = item.PhoneNumber;
            newCust.Name = item.Name;
            newCust.Address= item.Address;  
         
            dbcontext.SaveChanges();
        }

        public async Task<Customer>? GetCustomerById(string id)=> GetAll().Result. Find(x=> x.Id==id);


    }
}
