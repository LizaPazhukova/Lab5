using AutoMapper;
using EFCodeFirst.DAL;
using EFCodeFirst.DAL.Entities;
using Logic.DTO;
using Logic.Interfaces;
using System;
//using SQL_ADO.DAL;
//using SQL_ADO.DAL.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Logic.Services
{
    public class ProviderService: IProviderService
    {
        private readonly IUnitOfWork db;
        private readonly IMapper mapper;

        public ProviderService(IUnitOfWork uow)
        {
            db = uow;
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Provider, ProviderDTO>());
            mapper = new Mapper(config);
        }

        public IEnumerable<ProviderDTO> GetAll()
        {
            return mapper.Map<IEnumerable<Provider>, List<ProviderDTO>>(db.Providers.GetAll());
        }

        public ProviderDTO GetById(int id)
        {
            var provider = db.Providers.Get(id);
            if (provider == null)
                throw new ValidationException("Supplier doesn't exist");
        
            return mapper.Map<Provider, ProviderDTO>(provider);
        }

        public IEnumerable<ProviderDTO> GetProvidersByCategory(CategoryDTO categoryDTO)
        {
            return mapper.Map<IEnumerable<Provider>, List<ProviderDTO>>(db.Providers.GetAll().
                          Where(x => x.Products.Select(p => p.Id).Any(id => id == categoryDTO.Id)));
        }

        public void Create(ProviderDTO item)
        {
            if (item == null)
                throw new ArgumentException();

            var supplier = new Provider()
            {
                Name = item.Name,
                City = item.City
            };

            db.Providers.Create(supplier);
            db.Save();
        }

        public void Delete(int providerId)
        {
            db.Providers.Delete(providerId);
            db.Save();
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}

