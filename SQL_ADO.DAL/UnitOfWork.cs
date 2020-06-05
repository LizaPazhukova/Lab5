using SQL_ADO.DAL.Entities;
using SQL_ADO.DAL.Gateways;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL_ADO.DAL
{
    public class UnitOfWork: IUnitOfWork
    {
        private ProductCategoryGateway productCategoryGateway;
        private ProductGateway productGateway;
        private ProviderGateway providerGateway;

        private readonly ADOContext context;

        public UnitOfWork(string connectionString)
        {
            context = new ADOContext(connectionString);
        }

        public IGateway<ProductCategory> ProductCategories
        {
            get
            {
                if (productCategoryGateway == null)
                {
                    productCategoryGateway = new ProductCategoryGateway(context);
                }
                return productCategoryGateway;
            }
        }

        public IGateway<Provider> Providers
        {
            get
            {
                if (providerGateway == null)
                {
                    providerGateway = new ProviderGateway(context);
                }
                return providerGateway;
            }
        }

        public IGateway<Product> Products
        {
            get
            {
                if (productGateway == null)
                {
                    productGateway = new ProductGateway(context);
                }
                return productGateway;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
