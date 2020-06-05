using Autofac;
using EFCodeFirst.DAL.Repositories;

namespace EFCodeFirst.DAL
{

    public class EFDalModule : Module
    {

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();

            builder.RegisterType<ShopContext>();

            builder.RegisterType<ProductRepository>().As<IProductRepository>();
            builder.RegisterType<ProductCategoryRepository>().As<IProductCategoryRepository>();
            builder.RegisterType<ProviderRepository>().As<IProviderRepository>();
        }
    }
}
