using System;
using System.Collections.Generic;
using System.Text;

namespace EFCodeFirst.DAL.Entities
{
    public class ProductCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<Product> Products { get; set; }
        public ProductCategory()
        {
            Products = new List<Product>();
        }
        
        
    }
}
