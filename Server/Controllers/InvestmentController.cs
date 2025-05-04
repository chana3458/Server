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
        public List<BlInvestment> GetAll()
        {

            return investment.GetAll();
        }
        [HttpGet("GetInvestmentByName/{id}")]
        public BlInvestment getInvestmentByName(String name)
        {

            return investment.getInvestmentByName(name);
        }

        [HttpPost("AddInvstment")]
        public void AddInvstment([FromBody] BlInvestment inv)
        {

            investment.create(inv);

        }


        [HttpDelete("DeleteInvestment/{id}")]
        public void DeleteInvestment(String id)
        {

            investment.DeleteById(id);

        }

        [HttpPut("UpdateInvstment")]
        public void UpdateInvstment([FromBody] BlInvestment inv)
        {

            investment.update(inv);

        }
    }

}
