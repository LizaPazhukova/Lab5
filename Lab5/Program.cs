using Autofac;
using EFCodeFirst.DAL;
using EFCodeFirst.DAL.Repositories;
using SQL_ADO.DAL.Gateways;
using System;
using System.Linq;
using System.Configuration;
using Logic.Interfaces;
using Logic.Services;

namespace Lab5
{
    class Program
    {
        static void Main(string[] args)
        {
            //var container = ConfigureContainer();
            //using (var scope = container.BeginLifetimeScope())
            //{
            //    var productService = scope.Resolve<IProductService>();
            //    var products = productService.GetAll().ToList();
            //    foreach (var item in products)
            //        Console.WriteLine(item.Name + " " + item.Price);
            //    var productsByCategory = productService.GetByCategory(new Logic.DTO.CategoryDTO { Id = 1, Name = "Category1" });
            //    foreach (var item in productsByCategory)
            //        Console.WriteLine(item.Name + " " + item.Price);
            //    //var category = unitOfWork.ProductCategories.GetById(1);
            //}
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ShopContext;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            ProductGateway pr = new ProductGateway(connectionString);
            var products2 = pr.GetAll();
            foreach (var item in products2)
                Console.WriteLine(item.Name + " " + item.Price);
            //Console.WriteLine(prod.Name);
            Console.ReadLine();


        }

        private static IContainer ConfigureContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();

            builder.RegisterType<ShopContext>();

            builder.RegisterType<ProductRepository>().As<IProductRepository>();
            builder.RegisterType<ProductCategoryRepository>().As<IProductCategoryRepository>();
            builder.RegisterType<ProviderRepository>().As<IProviderRepository>();
            builder.RegisterType<CategoryService>().As<IProductCategoryService>();
            builder.RegisterType<ProductService>().As<IProductService>();
            builder.RegisterType<ProviderService>().As<IProviderService>();

            return builder.Build();
        }
    }
}
