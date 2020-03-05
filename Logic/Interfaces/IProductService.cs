using EFCodeFirst.DAL.Entities;
using Logic.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Interfaces
{
    public interface IProductService
    {
        IEnumerable<ProductDTO> GetAll();
        ProductDTO GetById(int id);
        void Create(ProductDTO item);
        void Delete(int productId);
        IEnumerable<ProductDTO> GetByCategory(CategoryDTO category);
        IEnumerable<ProductDTO> GetByProvider(ProviderDTO provider);
        IEnumerable<ProductDTO> GetByUserCondition(Func<Product, bool> predicate);
        void Dispose();
    }
}
