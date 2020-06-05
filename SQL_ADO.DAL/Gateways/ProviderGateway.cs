using SQL_ADO.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL_ADO.DAL.Gateways
{
    public class ProviderGateway: IGateway<Provider>
    {
        private readonly IADOContext context;

        public ProviderGateway(IADOContext context)
        {
            this.context = context;
        }

        public IEnumerable<Provider> GetAll()
        {
            string query = "SELECT * FROM Providers Left Join ProviderProducts On Providers.Id = ProviderProducts.Provider_Id " +
                           "Left  Join Products On ProviderProducts.Product_Id = Products.Id";
            var providers = new Dictionary<int, Provider>();
            using (SqlCommand command = new SqlCommand(query))
            {
                context.CreateCommand(command);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        Provider provider;
                        if (!providers.ContainsKey(id))
                        {
                            provider = new Provider()
                            {
                                Id = id,
                                City = reader.GetString(1),
                                Name = reader.GetString(2),
                            };
                            providers.Add(id, provider);
                        }

                        provider = providers[id];
                        if (reader.IsDBNull(5))
                        {
                            continue;
                        }
                        provider.Products.Add(new Product
                        {
                            Id = reader.GetInt32(5),
                            Name = reader.GetString(6),
                            Price = reader.GetDouble(7),
                            ProductCategoryId = reader.GetInt32(8)
                        }); ;

                    }
                }
            }
            return providers.Values.ToList();
        }
        public Provider Get(int id)
        {
            string query = "SELECT * FROM Providers Left Join ProviderProducts On Providers.Id = ProviderProducts.Provider_Id " +
                           "Left Join Products On ProviderProducts.Product_Id = Products.Id where Providers.Id = @Id";
            var providers = new Dictionary<int, Provider>();
            Provider provider = null;
            using (SqlCommand command = new SqlCommand(query))
            {
                command.Parameters.AddWithValue("Id", id);
                context.CreateCommand(command);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (!providers.ContainsKey(id))
                        {
                            provider = new Provider()
                            {
                                Id = id,
                                City = reader.GetString(1),
                                Name = reader.GetString(2),

                            };
                            providers.Add(id, provider);
                        }

                        provider = providers[id];
                        if (reader.IsDBNull(5))
                        {
                            continue;
                        }
                        provider.Products.Add(new Product
                        {
                            Id = reader.GetInt32(5),
                            Name = reader.GetString(6),
                            Price = reader.GetDouble(7),
                            ProductCategoryId = reader.GetInt32(8)
                        }); ;
                    }
                }
            }
            return provider;
        }
        public void Create(Provider provider)
        {
            string query = "INSERT INTO Providers (City, Name) Values(@City, @Name)";

            using (SqlCommand command = new SqlCommand(query))
            {
                command.Parameters.AddWithValue("City", provider.City);
                command.Parameters.AddWithValue("Name", provider.Name);
                context.CreateCommand(command);
                command.ExecuteNonQuery();
            }
        }

        public void Delete(int providerId)
        {
            string query = "Delete From Providers Where Id = @Id";

            using (SqlCommand command = new SqlCommand(query))
            {
                command.Parameters.AddWithValue("Id", providerId);
                context.CreateCommand(command);
                command.ExecuteNonQuery();
            }
        }
    }
}

