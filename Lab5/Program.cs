using Autofac;
using EFCodeFirst.DAL;
using System;
using System.Linq;
using Logic.Interfaces;
//using SQL_ADO.DAL;
using Logic;

namespace Lab5
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = ConfigureContainer();
            using (var scope = container.BeginLifetimeScope())
            {
                var productService = scope.Resolve<IProductService>();
                //var products = productService.GetAll().ToList();
                //foreach (var item in products)
                //    Console.WriteLine(item.Name + " " + item.Price);
                var productsByCategory = productService.GetByCategory(new Logic.DTO.CategoryDTO { Id = 1, Name = "Category1" });
                foreach (var item in productsByCategory)
                   Console.WriteLine(item.Name + " " + item.Price);
                //var product = productService.GetById(3);
                //Console.WriteLine(product.Name);
                //var product = productService.GetByUserCondition(pr=>pr.Name=="Product1").FirstOrDefault();
                //Console.WriteLine(product.Name + " " + product.Price);
                //var providerService = scope.Resolve<IProviderService>();
                //var providers = providerService.GetAll();
                //foreach (var item in providers)
                //    Console.WriteLine(item.Name + " " + item.City);
                //var proCat = providerService.GetProvidersByCategory(new Logic.DTO.CategoryDTO { Id = 1, Name = "Category1" });
                //foreach (var item in proCat)
                //   Console.WriteLine(item.Name + " " + item.City);

            }

            Console.ReadLine();


        }

        private static IContainer ConfigureContainer()
        {
            var builder = new ContainerBuilder();

            //builder.RegisterModule(new ADODalModule());
            builder.RegisterModule(new EFDalModule());
            builder.RegisterModule(new ServiceModule());
            
            return builder.Build();
        }
    }
}
