using Autofac;
using Logic.Interfaces;
using Logic.Services;

namespace Logic
{
    public class ServiceModule : Module
    {

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CategoryService>().As<IProductCategoryService>();
            builder.RegisterType<ProductService>().As<IProductService>();
            builder.RegisterType<ProviderService>().As<IProviderService>();
        }

    }
}
