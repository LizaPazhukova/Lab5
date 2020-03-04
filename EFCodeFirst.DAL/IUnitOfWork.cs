using EFCodeFirst.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCodeFirst.DAL
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Product> Products { get; }
        IRepository<ProductCategory> ProductCategories { get; }
        IRepository<Provider> Providers { get; }
        void Save();
    }
}
