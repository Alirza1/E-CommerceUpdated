using Dapper;
using E_CommerceDapper.DataAccess.Abstractions;
using E_CommerceDapper.DataAccess.Concretes;
using E_CommerceDapper.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CommerceDapper.Domain.Services
{
    public class CategoryService
    {
        private readonly IRepository<Category> _categoryRepo;
        public string ConnectionString { get; set; }

        public CategoryService()
        {
            _categoryRepo = new CategoryRepository();
            ConnectionString = ConfigurationManager.ConnectionStrings["MyConnString"].ConnectionString;
        }

        public async Task<IEnumerable<Product>> ProductOfSelectedCategoriesAsync(string categoryName)
        {
            using (var conn=new SqlConnection(ConnectionString))
            {
                var sql = (@"select *from Products as P
                              inner join Categories as C
                              on P.CategoryId=C.CategoryID
                              where C.CategoryName=@CategoryName");

                var products =  await conn.QueryAsync<Product, Category, Product>(sql,
                    (product, category) =>
                    {
                        product.Category=category;
                        return product;
                    }, new {CategoryName=categoryName} ,splitOn: "CategoryID");
                return products;
            }

        }
    }
}
