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
        public List<BlRequest> GetAll()
        {

            return request.GetAll();
        }


        [HttpPost("AddRequest")]
        public void AddRequest([FromBody] BlRequest req)
        {

            request.create(req);

        }


        [HttpDelete("DeleteRequest/{id}")]
        public void DeleteRequest( int id)
        {
            ((BlRequestService)request).deleteInt(id);
            //request.deleteById(id);

        }

        [HttpPut("UpdateRequest")]
        public void UpdateRequest([FromBody] BlRequest req)
        {

            request.update(req);

        }
    }
}

