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
           await dbcontext.SaveChangesAsync();
        }

        public async Task Delete(String id)
        {
           Customer? cust= dbcontext.Customers.Find(id);
            dbcontext.Customers.Remove(cust);
          await  dbcontext.SaveChangesAsync();
        }


    
           
            //.Include(x => x.RequestDetails).
        
        public async Task<List<Customer>> GetAll()
            => dbcontext.Customers.Include(x=> x.RequestDetails).ToList();

        public async Task update(Customer item) {
            //Customer? newCust = await GetAll().FindAsync(x => x.Id == item.Id);

            List<Customer> customers = this.GetAll().Result ;
            Customer ? newCust = customers.FirstOrDefault(x => x.Id == item.Id);
           

           newCust.Id = item.Id;
            newCust.PhoneNumber = item.PhoneNumber;
            newCust.Name = item.Name;
            newCust.Address= item.Address;  
         
          await dbcontext.SaveChangesAsync();
        }

        public async Task<Customer?> GetCustomerById(string id)=>
             this.GetAll().Result.Find(x=> x.Id==id);

        
    }
}
