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
        List<BlRequest> GetAll();
        void create(BlRequest request);
        void deleteById(String id);
        void update(BlRequest request);
         RequestDetail castToDal(BlRequest request);
        BlRequest castToBl(RequestDetail request);



    }
}
