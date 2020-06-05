using AutoMapper;
using EFCodeFirst.DAL;
using EFCodeFirst.DAL.Entities;
using Logic.DTO;
using Logic.Interfaces;
//using SQL_ADO.DAL;
//using SQL_ADO.DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Logic.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork db;
        private readonly IMapper _mapper;

        public ProductService(IUnitOfWork uow)
        {
            db = uow;
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Product, ProductDTO>());
            _mapper = new Mapper(config);
        }

        public IEnumerable<ProductDTO> GetAll()
        {
            return _mapper.Map<IEnumerable<Product>, List<ProductDTO>>(db.Products.GetAll());
        }

        public ProductDTO GetById(int id)
        {
            var product = db.Products.Get(id);
            if (product == null)
                throw new ValidationException("Product doesn't exist");
            return _mapper.Map<Product, ProductDTO>(product);
        }

        public void Create(ProductDTO item)
        {
            if (item == null)
                throw new ArgumentException();

            var product = new Product()
            {
                Name = item.Name,
                Price = item.Price
            };

            db.Products.Create(product);
            db.Save();
        }

        public void Delete(int productId)
        {
            db.Products.Delete(productId);
            db.Save();
        }

        public IEnumerable<ProductDTO> GetByCategory(CategoryDTO categoryDTO)
        {
            if (categoryDTO == null)
                throw new ArgumentException();

            return _mapper.Map<IEnumerable<Product>, List<ProductDTO>>(db.Products.GetAll().Where(x => x.ProductCategory.Name == categoryDTO.Name));
           
        }

        public IEnumerable<ProductDTO> GetByProvider(ProviderDTO providerDTO)
        {
            if (providerDTO == null)
                throw new ArgumentException();

            return _mapper.Map<IEnumerable<Product>, List<ProductDTO>>(db.Products.GetAll().Where(x => x.Providers.Select(p => p.Id).Contains(providerDTO.Id)));
        }

        public IEnumerable<ProductDTO> GetByUserCondition(Func<Product, bool> predicate)
        {
            var products = db.Products.GetAll().Where(predicate);
            if (products == null)
                throw new ValidationException("Products doesn't exist");
            return _mapper.Map<IEnumerable<Product>, List<ProductDTO>>(products);
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
