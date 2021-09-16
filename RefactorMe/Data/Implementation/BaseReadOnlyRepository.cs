using System;
using System.Linq;
using System.Linq.Expressions;

namespace RefactorMe.Data.Implementation
{
    public abstract class BaseReadOnlyRepository<T> : IReadOnlyRepository<T> where T : class
    {
        protected abstract T[] Data { get; }

        protected abstract IQueryable<T> GetProducts(double changePrice = 1.0);

        public IQueryable<T> GetAll()
        {
            return Data.AsQueryable();
        }

        public IQueryable<T> Get(Expression<Func<T, bool>> predicate)
        {
            return Data.AsQueryable().Where(predicate);
        }

        public IQueryable<T> GetAllProducts(double changePrice = 1.0)
        {
            return GetProducts(changePrice);
        }
    }
}
