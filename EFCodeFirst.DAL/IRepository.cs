using System;
using System.Linq;
using System.Linq.Expressions;

namespace EFCodeFirst.DAL
{
    public interface IRepository<T>
    {
        IQueryable<T> GetAll(params Expression<Func<T, object>>[] properties);
        void Create(T entity);
        void Delete(int id);
        T GetById(int id);
        void Update(T entity);
    }
}
