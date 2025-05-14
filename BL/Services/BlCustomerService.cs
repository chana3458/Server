using BL.Api;
using BL.Models;
using Dal.Api;
using Dal.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
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

            foreach (var x in customer.RequestDetails.ToList())
            {
                  newCustomer.RequestDetails.Add(await request.castToBl(x));
            }

            return newCustomer;

        }

        public async Task create(BlCustomer customer)
        {
            Customer newCustomer =await castToDal(customer);
            if (await getCustomerById(newCustomer.Id) != null)
                throw new Exception("id exsistes");
           else await dal.Customer.create(newCustomer);
            
        }

        public async Task DeleteById(String id)
        {
            
          await  dal.Customer.Delete(id);
        }
       
        public async  Task<List<BlCustomer>> GetAll()
        {
          var cList=  await dal.Customer.GetAll();

           List<BlCustomer> list= new List<BlCustomer>();

            //cList.ForEach(  p =>  list.Add(castToBl(p)));
            var tasks = cList.Select(async p =>await castToBl(p));
            var results = await Task.WhenAll(tasks);
            list.AddRange(results);

            return list;    
        }

     
        public async Task<BlCustomer> getCustomerById(string id)
        {
            var cust = await dal.Customer.GetCustomerById(id);
            if (cust == null)
                return null;
            //throw new NullReferenceException("cust not found");

            BlCustomer nc = await castToBl(cust);
            return nc;
        }

        public async Task update(BlCustomer customer)
        {
            Customer newCustomer = await  castToDal(customer);
           await dal.Customer.update(newCustomer);
          
        }

        
    }
}
