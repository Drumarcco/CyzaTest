using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace WebApi.DataAccess
{
    interface IService<T>
    {
        Task<int> Save(T obj);
        Task<int> Update(T obj);
        Task<int> Delete(T obj);
        Task<List<T>> GetAll();
    }
}