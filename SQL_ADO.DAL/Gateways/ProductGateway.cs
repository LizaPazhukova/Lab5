using SQL_ADO.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL_ADO.DAL.Gateways
{
    public class ProductGateway : IGateway<Product>
    {
        private readonly IADOContext context;

        public ProductGateway(IADOContext context)
        {
            this.context = context;
        }

        public IEnumerable<Product> GetAll()
        {
            string query = "SELECT * FROM Products Left Join ProviderProducts On Products.Id = ProviderProducts.Product_Id " +
                           "Left Join Providers On ProviderProducts.Provider_Id = Providers.Id";
            var products = new Dictionary<int, Product>();
            using (SqlCommand command = new SqlCommand(query))
            {
                context.CreateCommand(command);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        Product product;
                        if (!products.ContainsKey(id))
                        {
                            product = new Product()
                            {
                                Id = id,
                                Name = reader.GetString(1),
                                Price = reader.GetDouble(2),
                                ProductCategoryId = reader.GetInt32(3)
                            };
                            products.Add(id, product);
                        }

                        product = products[id];

                        if (reader.IsDBNull(6))
                        {
                            continue;
                        }


                        product.Providers.Add(new Provider
                        {
                            Id = reader.GetInt32(6),
                            City = reader.GetString(7),
                            Name = reader.GetString(8)
                        });

                    }
                }
            }
            return products.Values.ToList();
        }
        public Product Get(int id)
        {
            string query = "SELECT * FROM Products Left Join ProviderProducts On Products.Id = ProviderProducts.Product_Id " +
                           "Left Join Providers On ProviderProducts.Provider_Id = Providers.Id Where Products.Id = @Id";
           var products = new Dictionary<int, Product>();
            Product product = null;
            using (SqlCommand command = new SqlCommand(query))
            {

                command.Parameters.AddWithValue("Id", id);
                context.CreateCommand(command);
                using (SqlDataReader reader = command.ExecuteReader())

                    while (reader.Read())
                    {
                        if (!products.ContainsKey(id))
                        {
                            product = new Product()
                            {
                                Id = id,
                                Name = reader.GetString(1),
                                Price = reader.GetDouble(2),

                            };
                            products.Add(id, product);
                        }

                        product = products[id];

                        if (reader.IsDBNull(6))
                        {
                            continue;
                        }


                        product.Providers.Add(new Provider
                        {
                            Id = reader.GetInt32(6),
                            City = reader.GetString(7),
                            Name = reader.GetString(8)
                        }); ;

                    }
            }
            return product;
        }
        public void Create(Product product)
        {
            string query = "INSERT INTO Products (Name, Price, ProductCategoryId) Values(@Name, @Price, @CategoryId)";

            using (SqlCommand command = new SqlCommand(query))
            {
       
                command.Parameters.AddWithValue("Name", product.Name);
                command.Parameters.AddWithValue("Price", product.Price);
                command.Parameters.AddWithValue("CategoryId", product.ProductCategoryId);

                context.CreateCommand(command);
                command.ExecuteNonQuery();
            }
        }

        public void Delete(int productId)
        {
            string query = "Delete From Products Where Id = @Id";

            using (SqlCommand command = new SqlCommand(query))
            {
                command.Parameters.AddWithValue("Id", productId);
                context.CreateCommand(command);
                command.ExecuteNonQuery();
            }
        }
    }
}
