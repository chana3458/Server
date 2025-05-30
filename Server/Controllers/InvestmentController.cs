﻿using BL.Api;
using BL.Models;
using Dal.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvstmentController : ControllerBase
    {
        IblInvestment investment;
        public InvstmentController(IBL manager)
        {
            investment = manager.Investment;
        }
        [HttpGet("GetAllInvstment")]
        public async Task<List<BlInvestment>> GetAll()
        {

            return await investment.GetAll();
        }
        [HttpGet("GetInvestmentById/{id}")]
        public async Task<BlInvestment> getInvestmentById(int id)
        {

            return await investment.getInvestmentById(id);
        }

        [HttpPost("AddInvstment")]
        public async Task AddInvstment([FromBody] BlInvestment inv)
        {

          await  investment.create(inv);

        }


        [HttpDelete("DeleteInvestment/{id}")]
        public async Task DeleteInvestment(int id)
        {

          await  investment.DeleteById(id);

        }

        

        [HttpPut("UpdateInvstment")]
        public async Task UpdateInvstment([FromBody] BlInvestment inv)
        {

           await investment.update(inv);

        }
    }

}
