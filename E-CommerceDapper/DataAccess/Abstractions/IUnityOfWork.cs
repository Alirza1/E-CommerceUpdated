using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CommerceDapper.DataAccess.Abstractions
{
    public interface IUnityOfWork
    {
        ICategoryRepository CategoryRepository { get; }
       
        IProductRepository ProductRepository { get; }
        IAdminRepository AdminRepository { get; }
        IUserRepository UserRepository { get; }
    }
}
