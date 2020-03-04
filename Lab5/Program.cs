using Autofac;
using EFCodeFirst.DAL;
using EFCodeFirst.DAL.Repositories;
using SQL_ADO.DAL.Gateways;
using System;
using System.Linq;
using System.Configuration;

namespace Lab5
{
    class Program
    {
        static void Main(string[] args)
        {
            //var container = ConfigureContainer();
            //using (var scope = container.BeginLifetimeScope())
            //{
            //    var unitOfWork = scope.Resolve<IUnitOfWork>();
            //    var products = unitOfWork.Products.GetAll().ToList();
            //    foreach (var item in products)
            //        Console.WriteLine(item.Name + " " + item.Price);
            //    var category = unitOfWork.ProductCategories.GetById(1);
            //}
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ShopContext;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            
            ProductGateway pr = new ProductGateway(connectionString);
            var products2 = pr.GetAll();
            var productsCount = products2.Count();
            Console.WriteLine(productsCount);
            foreach (var item in products2)
                Console.WriteLine(item.Name + " " + item.Price);
            //Console.WriteLine(prod.Name);
            Console.ReadLine();
            

        }

        //    private readonly IUnitOfWork _unitOfWork;
        //    public Program(IUnitOfWork unitOfWork)
        //    {
        //        _unitOfWork = unitOfWork;
        //    }
        //    public IEnumerable<Product> GetProductsWithSpecifiedCategory(ProductCategory productCategory)
        //    {
        //        return _unitOfWork.Products.GetAll().Where(p=>p.ProductCategoryId==productCategory.Id);
        //    }
        //    public IEnumerable<Provider> GetProvidersWithSpecifiedCategory(ProductCategory productCategory)
        //    {
        //        return _unitOfWork.Providers.GetAll().Where(p => p.Products.Select(pr=>pr.ProductCategoryId).Contains(productCategory.Id));
        //    }
        //    public IEnumerable<Product> GetProductsWithSpecifiedProvider(Provider provider)
        //    {
        //        return _unitOfWork.Products.GetAll().Where(p => p.Providers.Select(pr => pr.Id).Contains(provider.Id));
        //    }

        //private static IContainer ConfigureContainer()
        //{
        //    var builder = new ContainerBuilder();
        //    builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();

        //    builder.RegisterType<ShopContext>();

        //    builder.RegisterType<ProductRepository>().As<IProductRepository>();
        //    builder.RegisterType<ProductCategoryRepository>().As<IProductCategoryRepository>();
        //    builder.RegisterType<ProviderRepository>().As<IProviderRepository>();


        //    return builder.Build();
        //}
    }
}
