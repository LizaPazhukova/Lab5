using EFCodeFirst.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCodeFirst.DAL
{
    public class ShopContext: DbContext
    {
        static ShopContext()
        {
            Database.SetInitializer(new ShopDbInitializer());
        }
        public ShopContext()
            : base("ShopContext")
        {
            var ensureDLLIsCopied =
                System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Provider> Providers { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
    }
}
