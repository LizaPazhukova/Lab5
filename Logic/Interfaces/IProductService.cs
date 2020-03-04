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
        void Update(int id, ProductDTO item);
        void Delete(Product product);
        IEnumerable<ProductDTO> GetByCategory(ProductCategory category);
        IEnumerable<ProductDTO> GetByProvider(Provider provider);
        IEnumerable<ProductDTO> GetByUserCondition(Func<Product, bool> predicate);
        void Dispose();
    }
}
