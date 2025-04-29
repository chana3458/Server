using BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Api
{
    public interface IblCustomer
    {
        List<BlCustomer> GetAll();
        void create(BlCustomer customer);
        void DeleteById(String id);
        BlCustomer getCustomerById(String id);

        void update(BlCustomer customer);
        
    }
}
