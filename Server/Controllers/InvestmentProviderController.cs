using BL.Api;
using BL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvestmentProviderController : ControllerBase
    {


        IblInvestmentProvider investmentProvider;
        public InvestmentProviderController(IBL manager)
        {
            investmentProvider = manager.InvestmentProvider;
        }
        [HttpGet("GetAllInvestmentProviders")]
        public async Task<List<BlInvestmentProvider>> GetAll()
        {

            return investmentProvider.GetAll().Result   ;
        }


        [HttpPost("AddInvestmentProvider")]
        public async Task AddInvestmentProvider([FromBody] BlInvestmentProvider ip)
        {

            investmentProvider.create(ip);

        }


        [HttpDelete("DeleteInvestmentProvider/{id}")]
        public async Task DeleteInvestmentProvider( String id)

        {

            investmentProvider.DeleteById(id);

        }

        [HttpPut("UpdateInvestmentProvider")]
        public async Task UpdateInvestmentProvider([FromBody] BlInvestmentProvider ip)
        {

            investmentProvider.update(ip);

        }
    }
}

