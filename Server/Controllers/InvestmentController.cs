using BL.Api;
using BL.Models;
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

            return investment.GetAll().Result;
        }
        [HttpGet("GetInvestmentByName/{id}")]
        public async Task<BlInvestment> getInvestmentByName(String name)
        {

            return investment.getInvestmentByName(name).Result;
        }

        [HttpPost("AddInvstment")]
        public async Task AddInvstment([FromBody] BlInvestment inv)
        {

            investment.create(inv);

        }


        [HttpDelete("DeleteInvestment/{id}")]
        public async Task DeleteInvestment(String id)
        {

            investment.DeleteById(id);

        }

        [HttpPut("UpdateInvstment")]
        public async Task UpdateInvstment([FromBody] BlInvestment inv)
        {

            investment.update(inv);

        }
    }

}
