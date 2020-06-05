using SQL_ADO.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL_ADO.DAL
{
    public interface IUnitOfWork: IDisposable
    {
        IGateway<Provider> Providers { get; }

        IGateway<ProductCategory> ProductCategories { get; }

        IGateway<Product> Products { get; }

        void Save();
    }
}
