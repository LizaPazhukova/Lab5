using EFCodeFirst.DAL.Entities;

namespace EFCodeFirst.DAL.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
    }
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(ShopContext shopContext)
            : base(shopContext)
        { }
    }
    
}
