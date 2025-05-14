using Azure.Core;
using BL.Api;
using BL.Models;
using BL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        IblCustomer customer;
        public CustomerController(IBL manager)
        {
            customer = manager.Customer;
        }
        [HttpGet("GetAllCustomers")]
        public async Task<List<BlCustomer> > GetAll()
        {
            
            return await customer.GetAll() ;
        }
        [HttpGet("GetCustomerById/{id}")]
        public async Task<IActionResult>  GetCustomerById( String id)
        { try
            {
                 
                return   Ok( await customer.getCustomerById(id));
            }

            catch (Exception ex)
            {
                return  BadRequest(  new { Text = ex.Message });
            }


        }

        [HttpPost("AddCustomer")]
        public async Task<IActionResult> AddCustomer([FromBody] BlCustomer cust)
        {
            try { 
              await  customer.create(cust);
                return Ok(cust);
            }

            catch(Exception ex) { return BadRequest(new { Text=ex.Message}); 
            }

        }


        [HttpDelete("DeleteCustomer/{id}")]
        public async Task DeleteCustomer( String id)
        {

           await customer.DeleteById(id);

        }


       

        [HttpPut("UpdateCustomer")]
        public async Task UpdateCustomer([FromBody] BlCustomer cust)
        {

           await customer.update(cust);

        }
    }

}
