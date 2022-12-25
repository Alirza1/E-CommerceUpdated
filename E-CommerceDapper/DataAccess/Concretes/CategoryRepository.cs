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
using System.Windows;

namespace E_CommerceDapper.DataAccess.Concretes
{
    public class CategoryRepository : ICategoryRepository
    {
        public string ConnectionString { get; set; }

        public CategoryRepository()
        {
            ConnectionString = ConfigurationManager.ConnectionStrings["MyConnString"].ConnectionString;
        }

        public async Task Add(Category data)
        {
            using (var conn=new SqlConnection(ConnectionString))
            {
                await conn.ExecuteAsync(@"insert into Categories(CategoryName)
                             values(CName)",
                             new { CName = data.CategoryName});

                MessageBox.Show("New Category Add Successfully");
            }
        }

        public async Task Delete(int id)
        {
            using (var conn=new SqlConnection(ConnectionString))
            {
                await conn.ExecuteAsync(@"Delete from Categories where CategoryID=CId",
                    new { CId = id });

                MessageBox.Show("Category Delete Successfully");
            }
        }

        public async Task <Category> Get(int id)
        {
            using (var conn=new SqlConnection(ConnectionString))
            {
                var category = await conn.QueryAsync<Category>
                    (@"select *from Category
                     where CategoryId=@id",
                     new { id = @id });
                return category.First();
            }
        }

        public async Task <IEnumerable<Category>> GetAll()
        {
            using (var conn=new SqlConnection(ConnectionString))
            {
                var categories = await conn.QueryAsync<Category>(@"select *from Categories");
                return categories;
            }
        }

        public async Task Update(Category data)
        {
            using (var conn=new SqlConnection(ConnectionString))
            {
                await conn.ExecuteAsync(@"Update Categories
                             Set CategoryName=@Name
                             where CategoryID=@id",
                             new { Name = data.CategoryName, id = data.CategoryID });   
            }
        }
    }
}
