using EFCodeFirst.DAL.Entities;
using Logic.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Interfaces
{
    public interface IProductCategoryService
    {
        IEnumerable<CategoryDTO> GetAll();
        CategoryDTO GetById(int id);
        void Create(CategoryDTO item);
        void Update(int id, CategoryDTO item);
        void Delete(ProductCategory category);
        void Dispose();
    }
}
