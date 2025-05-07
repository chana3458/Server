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
        Task<List<BlCustomer>> GetAll();
        Task create(BlCustomer customer);
        Task DeleteById(String id);
       Task< BlCustomer> getCustomerById(String id);

        Task update(BlCustomer customer);
        
    }
}
