using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Api
{
    public interface ICrud<T>
    {
     
        List<T> GetAll();
        void create(T item); 

        void Delete(string item);

        void update(T item);
        
    }
}
