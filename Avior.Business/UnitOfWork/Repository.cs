using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Avior.Business.UnitOfWork
{
    public abstract class Repository<T> : IQueryable<T> where T : class
    {
        private readonly IQueryable<T> query;

        protected Repository(IQueryable<T> query)
        {
            this.query = query;
        }

        public Type ElementType
        {
            get { return query.ElementType; }
        }

        public Expression Expression
        {
            get { return query.Expression; }
        }

        public IQueryProvider Provider
        {
            get { return query.Provider; }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return query.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return query.GetEnumerator();
        }

        public abstract void AddObject(T entity);

        public abstract void AddObjects(IEnumerable<T> entities);

        public abstract void DeleteObject(T entity);

        public abstract void DeleteObjects(IEnumerable<T> entities);

        public void AddObject(IEnumerable<T> entities)
        {
            foreach (var entity in entities)
            {
                AddObject(entity);
            }
        }

        public void DeleteObject(IEnumerable<T> entities)
        {
            foreach (var entity in entities)
            {
                DeleteObject(entity);
            }
        }

        public abstract void ReloadObject(T entity);

        public abstract T FindById(decimal id);
    }
}
