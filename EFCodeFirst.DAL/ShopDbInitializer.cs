using EFCodeFirst.DAL.Entities;
using System.Collections.Generic;
using System.Data.Entity;

namespace EFCodeFirst.DAL
{
    class ShopDbInitializer : DropCreateDatabaseAlways<ShopContext>
    {
        protected override void Seed(ShopContext db)
        {
            Product product1 = new Product { Id = 1, Name = "Product1", Price = 25, ProductCategory = new ProductCategory { Id = 1, Name = "Category1" } };
            Product product2 = new Product { Id = 2, Name = "Product2", Price = 30, ProductCategory = new ProductCategory { Id = 2, Name = "Category2" } };
            db.Products.Add(product1);
            db.Products.Add(product2);
            Provider provider1 = new Provider { Id = 1, Name = "Provider1", Products = new List<Product> { product1, product2 } };
            Provider provider2 = new Provider { Id = 2, Name = "Provider2", Products = new List<Product> { product1 } };
            db.Providers.Add(provider1);
            db.Providers.Add(provider2);
            ProductCategory productCategory1 = new ProductCategory { Id = 1, Name = "Category1", Products = new List<Product> { product1 } };
            ProductCategory productCategory2 = new ProductCategory { Id = 2, Name = "Category2", Products = new List<Product> { product2 } };
            db.ProductCategories.Add(productCategory1);
            db.ProductCategories.Add(productCategory2);
            base.Seed(db);
        }
    }  
}
