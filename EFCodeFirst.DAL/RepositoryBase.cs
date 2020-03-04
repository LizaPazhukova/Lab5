using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EFCodeFirst.DAL
{
    public class RepositoryBase<T> : IRepository<T> where T : class
    {
        protected ShopContext ShopContext { get; set; }

        public RepositoryBase(ShopContext shopContext)
        {
            ShopContext = shopContext;
        }
        public IQueryable<T> GetAll(params Expression<Func<T, object>>[] properties)
        {
            var query = ShopContext.Set<T>() as IQueryable<T>;

            if (properties == null)
                return query.AsNoTracking();

            return properties.Aggregate(query, (current, property) => current.Include(property));
        }
        public void Create(T entity)
        {
            ShopContext.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            ShopContext.Set<T>().Remove(entity);
        }
        public T GetById(int id)
        {
            return ShopContext.Set<T>().Find(id);
        }
    }
}
