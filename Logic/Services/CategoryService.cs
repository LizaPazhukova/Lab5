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
    public class CategoryService : IProductCategoryService
    {
        private readonly IUnitOfWork db;

        public CategoryService(IUnitOfWork uow)
        {
            db = uow;
        }

        public IEnumerable<CategoryDTO> GetAll()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<ProductCategory, CategoryDTO>());
            var mapper = new Mapper(config);
            return mapper.Map<IEnumerable<ProductCategory>, List<CategoryDTO>>(db.ProductCategories.GetAll());
        }

        public CategoryDTO GetById(int id)
        {
            var category = db.ProductCategories.GetById(id);
            if (category == null)
                throw new ValidationException("Category doesn't exist");
            var config = new MapperConfiguration(cfg => cfg.CreateMap<ProductCategory, CategoryDTO>());
            var mapper = new Mapper(config);
            return mapper.Map<ProductCategory, CategoryDTO>(category);
        }

        public void Create(CategoryDTO item)
        {
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

