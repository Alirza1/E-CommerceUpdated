using Dapper;
using E_CommerceDapper.DataAccess.Abstractions;
using E_CommerceDapper.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CommerceDapper.DataAccess.Concretes
{
    public class UserRepository : IUserRepository
    {
        public string ConnectionString { get; set; }

        public UserRepository()
        {
            ConnectionString = ConfigurationManager.ConnectionStrings["MyConnString"].ConnectionString;
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            using (var conn = new SqlConnection(ConnectionString))
            {
                var users =await conn.QueryAsync<User>(@"select *from [User]");
                return users;
            }
        }

        public Task<User> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task Add(User data)
        {
            throw new NotImplementedException();
        }

        public Task Update(User data)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
