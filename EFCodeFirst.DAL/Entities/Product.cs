using System.Collections.Generic;

namespace EFCodeFirst.DAL.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int ProductCategoryId { get; set; }
        public ProductCategory ProductCategory { get; set; }
        public List<Provider> Providers { get; set; }
        public Product()
        {
            Providers = new List<Provider>();
        }
    }
}
