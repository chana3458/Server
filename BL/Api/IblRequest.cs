using BL.Models;
using Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace BL.Api
{
    public interface IblRequest
    {
        Task<List<BlRequest>> GetAll();
        Task create(BlRequest request);
        Task deleteById(String id);
        Task update(BlRequest request);
        Task<RequestDetail> castToDal(BlRequest request);
        Task<BlRequest> castToBl(RequestDetail request);



    }
}
