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
        public List<BlInvestmentProvider> GetAll()
        {

            return investmentProvider.GetAll();
        }


        [HttpPost("AddInvestmentProvider")]
        public void AddInvestmentProvider([FromBody] BlInvestmentProvider ip)
        {

            investmentProvider.create(ip);

        }


        [HttpDelete("DeleteInvestmentProvider/{id}")]
        public void DeleteInvestmentProvider( String id)

        {

            investmentProvider.DeleteById(id);

        }

        [HttpPut("UpdateInvestmentProvider")]
        public void UpdateInvestmentProvider([FromBody] BlInvestmentProvider ip)
        {

            investmentProvider.update(ip);

        }
    }
}

