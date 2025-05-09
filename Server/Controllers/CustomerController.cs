﻿using BL.Api;
using BL.Models;
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
            
            return customer.GetAll().Result ;
        }
        [HttpGet("GetCustomerById/{id}")]
        public IActionResult GetCustomerById( String id)
        { try
            {
                 
                return Ok(customer.getCustomerById(id));
            }

            catch (Exception ex)
            {
                return BadRequest(new { Text = ex.Message });
            }


        }

        [HttpPost("AddCustomer")]
        public IActionResult AddCustomer([FromBody] BlCustomer cust)
        {
            try { 
            customer.create(cust);
                return Ok(cust);
            }

            catch(Exception ex) { return BadRequest(new { Text=ex.Message}); 
            }

        }


        [HttpDelete("DeleteCustomer/{id}")]
        public void DeleteCustomer( String id)
        {

            customer.DeleteById(id);

        }

        [HttpPut("UpdateCustomer")]
        public void UpdateCustomer([FromBody] BlCustomer cust)
        {

            customer.update(cust);

        }
    }

}
