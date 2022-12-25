using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CommerceDapper.DataAccess.Abstractions
{
    public interface IRepository<T>
    {
        Task <IEnumerable<T>> GetAll();

        Task<T> Get(int id);

        Task Add(T data);

        Task Update(T data);

        Task Delete(int id);
    }
}
