using BL.Api;
using BL.Models;
using BL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReqeustsController : ControllerBase
    {

        IblRequest request;
        public ReqeustsController(IBL manager)
        {
            request = manager.Request;
        }
        [HttpGet("GetAllRequests")]
        public async Task<List<BlRequest>> GetAll()
        {

            return await request.GetAll();
        }


        [HttpPost("AddRequest")]
        public async Task AddRequest([FromBody] BlRequest req)
        {

          await  request.create(req);

        }


        [HttpDelete("DeleteRequest/{id}")]
        public async Task DeleteRequest( int id)
        {
           await ((BlRequestService)request).deleteInt(id);
            //request.deleteById(id);

        }

        [HttpPut("UpdateRequest")]
        public async Task UpdateRequest([FromBody] BlRequest req)
        {

           await request.update(req);

        }
    }
}

