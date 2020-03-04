using EFCodeFirst.DAL.Entities;
using System;

namespace EFCodeFirst.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private ShopContext _context;
        private bool _isDisposed;

        public UnitOfWork(ShopContext context)
        {
            _context = context;

        }
        private IRepository<Product> _productRepository;
        private IRepository<ProductCategory> _productCategoryRepository;
        private IRepository<Provider> _providerRepository;

        public IRepository<Product> Products
        {
            get
            {
                return _productRepository ?? (_productRepository = new RepositoryBase<Product>(_context));
            }
        }
        public IRepository<ProductCategory> ProductCategories
        {
            get
            {
                return _productCategoryRepository ?? (_productCategoryRepository = new RepositoryBase<ProductCategory>(_context));
            }
        }

        public IRepository<Provider> Providers
        {
            get
            {
                return _providerRepository ?? (_providerRepository = new RepositoryBase<Provider>(_context));
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public virtual void Dispose(bool disposing)
        {
            if (!_isDisposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }

            _isDisposed = true;
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
