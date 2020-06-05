using SQL_ADO.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL_ADO.DAL.Gateways 
{
    public class ProductCategoryGateway : IGateway<ProductCategory>
    {
        private readonly IADOContext context;

        public ProductCategoryGateway(IADOContext context)
        {
            this.context = context;
        }
        public IEnumerable<ProductCategory> GetAll()
        {
            
            string query = "SELECT * FROM ProductCategories";
            List<ProductCategory> list = null;
            using (SqlCommand command = new SqlCommand(query)) 
            { 
                context.CreateCommand(command);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    list = new List<ProductCategory>();

                    while (reader.Read())
                    {
                        list.Add(new ProductCategory()
                        {
                            Id = reader.GetInt32(0),
                            Name = reader.GetString(1)
                        });
                    }
                }
            }
            return list;
        }
        public ProductCategory Get(int id)
        {
            string query = "SELECT * FROM ProductCategories Where Id = @Id";
            ProductCategory category = null;
            using (SqlCommand command = new SqlCommand(query))
            {
                command.Parameters.AddWithValue("Id", id);
                context.CreateCommand(command);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        category = new ProductCategory()
                        {
                            Id = reader.GetInt32(0),
                            Name = reader.GetString(1)
                        };
                    }
                }
            }

            return category;
        }
        public void Create(ProductCategory category)
        {
            string query = "INSERT INTO ProductCategories VALUES (@CategoryName)";

            if (category != null)
            {
                using (SqlCommand command = new SqlCommand(query))
                {
                    command.Parameters.AddWithValue("CategoryName", category.Name);
                    context.CreateCommand(command);
                    command.ExecuteNonQuery();
                }
            }

        }

        public void Delete(int id)
        {
            string query = "Delete From ProductCategories Where Id = @Id";

            using (SqlCommand command = new SqlCommand(query))
            {
                command.Parameters.AddWithValue("Id", id);
                context.CreateCommand(command);
                command.ExecuteNonQuery();
            }
        }

        

  
    }
}
