using EFCodeFirst.DAL.Entities;
using Logic.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Interfaces
{
    public interface IProviderService
    {
        IEnumerable<ProviderDTO> GetAll();
        ProviderDTO GetById(int id);
        IEnumerable<ProviderDTO> GetProvidersByCategory(CategoryDTO category);
        void Create(ProviderDTO item);
        void Delete(int providerId);
        void Dispose();
    }
}
