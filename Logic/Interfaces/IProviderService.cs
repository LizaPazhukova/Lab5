using Logic.DTO;
using System.Collections.Generic;

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
