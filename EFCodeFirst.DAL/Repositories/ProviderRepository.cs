using EFCodeFirst.DAL.Entities;

namespace EFCodeFirst.DAL.Repositories
{
    public interface IProviderRepository : IRepository<Provider>
    {
    }
    public class ProviderRepository : RepositoryBase<Provider>, IProviderRepository
    {
        public ProviderRepository(ShopContext shopContext)
            : base(shopContext)
        { }
    }
}
