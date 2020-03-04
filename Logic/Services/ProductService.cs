using AutoMapper;
using EFCodeFirst.DAL;
using EFCodeFirst.DAL.Entities;
using Logic.DTO;
using Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Logic.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork db;

        public ProductService(IUnitOfWork uow)
        {
            db = uow;
        }

        public IEnumerable<ProductDTO> GetAll()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Product, ProductDTO>());
            var mapper = new Mapper(config);
           // Mapper.Initialize(cfg => cfg.CreateMap<Product, ProductDTO>());
            return mapper.Map<IEnumerable<Product>, List<ProductDTO>>(db.Products.GetAll());
        }

        public ProductDTO GetById(int id)
        {
            var product = db.Products.GetById(id);
            if (product == null)
                throw new ValidationException("Product doesn't exist");
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Product, ProductDTO>());
            var mapper = new Mapper(config);
            //Mapper.Initialize(cfg => cfg.CreateMap<Product, ProductDto>());
            return mapper.Map<Product, ProductDTO>(product);
        }

        public void Create(ProductDTO item)
        {
            var product = new Product()
            {
                Name = item.Name,
                Price = item.Price
            };

            db.Products.Create(product);
            db.Save();
        }

        public void Update(int id, ProductDTO item)
        {
            var product = db.Products.GetById(id);
            if (product == null)
                return;

            product.Name = item.Name;
            product.Price = item.Price;

            db.Save();
        }

        public void Delete(Product product)
        {
            db.Products.Delete(product);
            db.Save();
        }

        public IEnumerable<ProductDTO> GetByCategory(ProductCategory category)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Product, ProductDTO>());
            var mapper = new Mapper(config);
            return mapper.Map<IEnumerable<Product>, List<ProductDTO>>(db.Products.GetAll().Where(x => x.ProductCategory.Name == category.Name));
           
        }

        public IEnumerable<ProductDTO> GetByProvider(Provider provider)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Product, ProductDTO>());
            var mapper = new Mapper(config);
            return mapper.Map<IEnumerable<Product>, List<ProductDTO>>(db.Products.GetAll().Where(x => x.Providers.Contains(provider)));
        }

        public IEnumerable<ProductDTO> GetByUserCondition(Func<Product, bool> predicate)
        {
            var products = db.Products.GetAll().Where(predicate);
            if (products == null)
                throw new ValidationException("Products doesn't exist");
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Product, ProductDTO>());
            var mapper = new Mapper(config);
            return mapper.Map<IEnumerable<Product>, List<ProductDTO>>(products);
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
