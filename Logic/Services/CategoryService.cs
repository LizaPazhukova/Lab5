using AutoMapper;
using EFCodeFirst.DAL;
using EFCodeFirst.DAL.Entities;
using Logic.DTO;
using Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
//using SQL_ADO.DAL;
//using SQL_ADO.DAL.Entities;


namespace Logic.Services
{
    public class CategoryService : IProductCategoryService
    {
        private readonly IUnitOfWork db;
        private readonly IMapper mapper;

        public CategoryService(IUnitOfWork uow)
        {
            db = uow;
            var config = new MapperConfiguration(cfg => cfg.CreateMap<ProductCategory, CategoryDTO>());
            mapper = new Mapper(config);
        }

        public IEnumerable<CategoryDTO> GetAll()
        {      
            return mapper.Map<IEnumerable<ProductCategory>, List<CategoryDTO>>(db.ProductCategories.GetAll());
        }

        public CategoryDTO GetById(int id)
        {
            var category = db.ProductCategories.Get(id);
            if (category == null)
                throw new ValidationException("Category doesn't exist");
            return mapper.Map<ProductCategory, CategoryDTO>(category);
        }

        public void Create(CategoryDTO item)
        {
            if (item == null)
                throw new ArgumentException();

            var category = new ProductCategory()
            {
                Name = item.Name
            };

            db.ProductCategories.Create(category);
            db.Save();
        }

        public void Delete(int categoryId)
        {
            db.ProductCategories.Delete(categoryId);
            db.Save();
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}

