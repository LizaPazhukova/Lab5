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
        private string connectionString;

        public ProductGateway(string connection)
        {
            connectionString = connection;
        }


        public IEnumerable<Product> GetAll()
        {
            string query = "SELECT * FROM Products";
            ICollection<Product> products = new List<Product>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);

                command.Connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    ICollection<Provider> providers = new List<Provider>();
                    int id = reader.GetInt32(0);
                    string name = reader.GetString(1);
                    double price = reader.GetDouble(2);
                    //providers = GetProviders(id);
                    products.Add(new Product
                    {
                        Id = id,
                        Name = name,
                        Price = price,
                       // Providers = providers
                    });

                }
            }
            return products;
        }

        public Product Get(int id)
        {
            string query = "SELECT * FROM Products WHERE Products.Id = @id";
            Product prod = new Product();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);

                command.Connection.Open();
                SqlParameter idParam = new SqlParameter("@id", id);
                command.Parameters.Add(idParam);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    prod = new Product
                    {
                        Id = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Price = reader.GetDouble(2),
                        ProductCategoryId = reader.GetInt32(3)
                    };

                }

            }
            return prod;
        }
    }
}
