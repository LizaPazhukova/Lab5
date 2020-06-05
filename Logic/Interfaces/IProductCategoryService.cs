using Logic.DTO;
using System.Collections.Generic;

namespace Logic.Interfaces
{
    public interface IProductCategoryService
    {
        IEnumerable<CategoryDTO> GetAll();
        CategoryDTO GetById(int id);
        void Create(CategoryDTO item);
        void Delete(int categoryId);
        void Dispose();
    }
}
