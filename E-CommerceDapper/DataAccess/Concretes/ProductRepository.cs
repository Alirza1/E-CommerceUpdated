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

    public class ProductRepository : IProductRepository
    {

        private string ConnectionString { get; set; }

        public ProductRepository()
        {
            ConnectionString = ConfigurationManager.ConnectionStrings["MyConnString"].ConnectionString;
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            using (var conn = new SqlConnection(ConnectionString))
            {
                var sql = @"SELECT * FROM Products AS P
                        INNER JOIN Categories AS C
                        ON P.CategoryID=C.CategoryID";
                var products = await conn.QueryAsync<Product, Category, Product>(sql,
                    (product, category) =>
                    {
                        product.Category = category;
                        return product;
                    }, splitOn: "CategoryID");
                return products;
            }

        }

        public async Task<Product> Get(int id)
        {
            using (var conn = new SqlConnection(ConnectionString))
            {
                var sql = @"SELECT * FROM Products AS P
                        INNER JOIN Categories AS C
                        ON P.CategoryID=C.CategoryID
                        WHERE P.ProductID=@id";
                var products = await conn.QueryAsync<Product, Category, Product>(sql,
                    (product, category) =>
                    {
                        product.Category = category;
                        return product;
                    }, new { id = id }, splitOn: "CategoryID");
                return products.First();
            }
        }

        public async Task Add(Product data)
        {
            using (var conn = new SqlConnection(ConnectionString))
            {
                await conn.ExecuteAsync(@"insert into Product(ProductName,UnitPrice,UnitsInStock,CategoryID)
                             values @Name,@UnitPrice,@UnitsInStock,@CategoryId",
                            new
                            {
                                Name = data.ProductName,
                                UnitPrice = data.UnitPrice,
                                UnitsInStock = data.UnitsInStock,
                                CategoryId = data.CategoryId
                            });

                MessageBox.Show("Add Product Successfully");
            }
        }

        public async Task Update(Product data)
        {
            using (var conn = new SqlConnection(ConnectionString))
            {
                await conn.ExecuteAsync(@"Update Products
                             Set ProductName=@Name,UnitPrice=@UnitPrice,UitsInStock=@UnitsInStock,
                             CategoryId=@CategoryId",
                             new
                             {
                                 Name = data.ProductName,
                                 UnitPrice = data.UnitPrice,
                                 UnitPriceInStock = data.UnitsInStock,
                                 CategoryID = data.CategoryId
                             });
            }
        }

        public async Task Delete(int id)
        {
            using (var conn = new SqlConnection(ConnectionString))
            {
                 await conn.ExecuteAsync(@"Delete from Products where ProductID=PId",
                    new { PId = id });

                MessageBox.Show("Category Delete Successfully");
            }
        }
    }
}
