using EFCodeFirst.DAL.Entities;
using System.Collections.Generic;
using System.Data.Entity;

namespace EFCodeFirst.DAL
{
    class ShopDbInitializer : DropCreateDatabaseIfModelChanges<ShopContext>
    {
        protected override void Seed(ShopContext db)
        {
            ProductCategory productCategory1 = new ProductCategory { Id = 1, Name = "Category1" };
            ProductCategory productCategory2 = new ProductCategory { Id = 2, Name = "Category2" };
            db.ProductCategories.Add(productCategory1);
            db.ProductCategories.Add(productCategory2);
            Product product1 = new Product { Name = "Product1", Price = 25, ProductCategoryId = 1 };
            Product product2 = new Product { Name = "Product3", Price = 30, ProductCategoryId = 2 };
            Product product3 = new Product { Name = "Product2", Price = 35, ProductCategoryId = 1 };
            db.Products.Add(product1);
            db.Products.Add(product2);
            db.Products.Add(product3);
            Provider provider1 = new Provider { Id = 1, Name = "Provider1", City = "Poltava", Products = new List<Product> { product1, product2 } };
            Provider provider2 = new Provider { Id = 2, Name = "Provider2", City = "Kiev", Products = new List<Product> { product1 } };
            db.Providers.Add(provider1);
            db.Providers.Add(provider2);
            
            base.Seed(db);
        }
    }  
}
