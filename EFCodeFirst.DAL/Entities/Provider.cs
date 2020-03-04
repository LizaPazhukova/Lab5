using System;
using System.Collections.Generic;
using System.Text;

namespace EFCodeFirst.DAL.Entities
{
    public class Provider
    {
        public int Id { get; set; }
        public string City { get; set; }
        public string Name { get; set; }
        public virtual List<Product> Products {get;set;}
        public Provider()
        {
            Products = new List<Product>();
        }
    }
}
