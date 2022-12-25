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
    public class AdminRepository : IAdminRepository
    {
        public string ConnectionString { get; set; }

        public AdminRepository()
        {
            ConnectionString = ConfigurationManager.ConnectionStrings["MyConnString"].ConnectionString;
        }

        public async Task Add(Admin data)
        {
            throw new NotImplementedException();
        }

        public async Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task <Admin> Get(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Admin>> GetAll()
        {
            using (var conn=new SqlConnection(ConnectionString))
            {
                var admin =  await conn.QueryAsync<Admin>(@"select *from Admin");
                return admin.ToList();
            }
        }

        public Task Update(Admin data)
        {
            throw new NotImplementedException();
        }
    }
}
