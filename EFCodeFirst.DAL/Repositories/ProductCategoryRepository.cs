using EFCodeFirst.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCodeFirst.DAL.Repositories
{
    public interface IProductCategoryRepository : IRepository<ProductCategory>
    {
    }
    public class ProductCategoryRepository : RepositoryBase<ProductCategory>, IProductCategoryRepository
    {
        public ProductCategoryRepository(ShopContext shopContext)
            : base(shopContext)
        { }
    }
}
