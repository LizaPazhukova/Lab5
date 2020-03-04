using AutoMapper;
using EFCodeFirst.DAL;
using EFCodeFirst.DAL.Entities;
using Logic.DTO;
using Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Services
{
    public class ProviderService: IProviderService
    {
        private readonly IUnitOfWork db;

        public ProviderService(IUnitOfWork uow)
        {
            db = uow;
        }

        public IEnumerable<ProviderDTO> GetAll()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Provider, ProviderDTO>());
            var mapper = new Mapper(config);
            return mapper.Map<IEnumerable<Provider>, List<ProviderDTO>>(db.Providers.GetAll());
        }

        public ProviderDTO GetById(int id)
        {
            var provider = db.Providers.GetById(id);
            if (provider == null)
                throw new ValidationException("Supplier doesn't exist");
            var config = new MapperConfiguration(cfg => cfg.CreateMap<ProductCategory, CategoryDTO>());
            var mapper = new Mapper(config);
            return mapper.Map<Provider, ProviderDTO>(provider);
        }

        public IEnumerable<ProviderDTO> GetProvidersByCategory(ProductCategory category)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<ProductCategory, CategoryDTO>());
            var mapper = new Mapper(config);
            return mapper.Map<IEnumerable<Provider>, List<ProviderDTO>>(db.Providers.GetAll().Where(x => x.Products.Any(p => p.ProductCategory == category)));
        }

        public void Create(ProviderDTO item)
        {
            var supplier = new Provider()
            {
                Name = item.Name,
                City = item.City
            };

            db.Providers.Create(supplier);
            db.Save();
        }

        public void Update(int id, ProviderDTO item)
        {
            var supplier = db.Providers.GetById(id);
            if (supplier == null)
                return;

            supplier.Name = item.Name;
            supplier.City = item.City;

            db.Save();
        }

        public void Delete(Provider provider)
        {
            db.Providers.Delete(provider);
            db.Save();
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}

