using E_CommerceDapper.DataAccess.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CommerceDapper.DataAccess.Concretes
{
    public class UnitOfWork : IUnityOfWork
    {
        public ICategoryRepository CategoryRepository => new CategoryRepository();

        public IProductRepository ProductRepository => new ProductRepository();

        public IAdminRepository AdminRepository => new AdminRepository();

        public IUserRepository UserRepository => new UserRepository();
    }
}
