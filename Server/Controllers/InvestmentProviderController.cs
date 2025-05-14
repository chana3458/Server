using BL.Api;
using BL.Models;
using Dal.Models;
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

            return await investmentProvider.GetAll()   ;
        }

        [HttpGet("GetInvestmentProviderById/{id}")]
        public async Task<IActionResult> GetInvestmentProviderById(String id)
        {
            try
            {

                return Ok(await investmentProvider.getInvestmentProviderById(id));
            }

            catch (Exception ex)
            {
                return BadRequest(new { Text = ex.Message });
            }


        }



        [HttpPost("AddInvestmentProvider")]
        public async Task AddInvestmentProvider([FromBody] BlInvestmentProvider ip)
        {

          await  investmentProvider.create(ip);

        }


        [HttpDelete("DeleteInvestmentProvider/{id}")]
        public async Task DeleteInvestmentProvider( String id)

        {

          await  investmentProvider.DeleteById(id);

        }

        [HttpPut("UpdateInvestmentProvider")]
        public async Task UpdateInvestmentProvider([FromBody] BlInvestmentProvider ip)
        {

          await  investmentProvider.update(ip);

        }
    }
}

