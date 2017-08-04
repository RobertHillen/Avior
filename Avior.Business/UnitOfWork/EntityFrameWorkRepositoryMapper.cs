using Avior.Base.Helpers;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avior.Business.UnitOfWork
{
    public sealed class EntityFrameWorkRepositoryMapper : IRepositoryMapper
    {
        private readonly DbContext _context;

        public EntityFrameWorkRepositoryMapper(DbContext context)
        {
            _context = context;
        }

        public void Save()
        {
            try
            {
                SaveChangesOrReset();
            }
            catch (DbEntityValidationException e)
            {
                var message = new StringBuilder();

                foreach (var eve in e.EntityValidationErrors)
                {
                    var entityType = eve.Entry.Entity.GetType().Name;
                    var entityState = eve.Entry.State;

                    message.AppendLine(string.Format("Entity of type '{0}' in state '{1}' has the following validation errors:", entityType, entityState));

                    foreach (var ve in eve.ValidationErrors)
                    {
                        message.AppendLine(string.Format("  - Property: '{0}', Error: '{1}'", ve.PropertyName, ve.ErrorMessage));
                    }
                }

                throw new DbEntityValidationException(message.ToString(), e);
            }
            catch (DbUpdateException e)
            {
                // Find SqlException with Number 547
                var sqlE = GetSqlExceptionWithNumber(e, 547);
                if (sqlE != null)
                {
                    throw ExceptionHelper.CreateAviorConstraintException(sqlE);
                }

                throw;
            }
        }

        private void ResetContext()
        {
            foreach (var entry in _context.ChangeTracker.Entries())
            {
                switch (entry.State)
                {
                    case EntityState.Modified:
                        entry.State = EntityState.Unchanged;
                        break;
                    case EntityState.Added:
                        entry.State = EntityState.Detached;
                        break;
                    case EntityState.Deleted:
                        entry.Reload();
                        break;
                }
            }
        }

        private void SaveChangesOrReset()
        {
            try
            {
                _context.SaveChanges();
            }
            catch (Exception)
            {
                ResetContext();

                throw;
            }
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public Repository<T> GetRepository<T>() where T : class
        {
            return new EntityRepository<T>(_context, _context.Set<T>());
        }

        public void AutoDetectChanges(bool enabled)
        {
            _context.Configuration.AutoDetectChangesEnabled = enabled;
        }

        public bool HasChanges()
        {
            // Check for changes in entities
            var hasChangesInEntities = (from entry in _context.ChangeTracker.Entries()
                                        where entry.State == EntityState.Added
                                              || entry.State == EntityState.Deleted
                                              || entry.State == EntityState.Modified
                                        select entry).Any();

            if (hasChangesInEntities)
            {
                return true;
            }

            // Check for changes in independent associations
            _context.ChangeTracker.DetectChanges();

            var objContext = ((IObjectContextAdapter)_context).ObjectContext;
            var hasChangesInIndependentAssociations =
                objContext.ObjectStateManager
                    .GetObjectStateEntries(EntityState.Added | EntityState.Deleted | EntityState.Modified)
                    .Any(e => e.IsRelationship);

            return hasChangesInIndependentAssociations;
        }

        #region Helpers

        /// <summary>
        ///     Finds an SqlException with the specified number within the exception recursively.
        ///     Sql error messages: http://msdn.microsoft.com/en-us/library/cc645611.aspx
        /// </summary>
        /// <param name="e"></param>
        /// <param name="number"></param>
        /// <returns></returns>
        private SqlException GetSqlExceptionWithNumber(Exception e, int number)
        {
            var asSqlException = e as SqlException;
            if (asSqlException != null)
            {
                if (asSqlException.Number == number)
                {
                    return asSqlException;
                }
            }
            else if (e.InnerException != null)
            {
                return GetSqlExceptionWithNumber(e.InnerException, number);
            }

            return null;
        }

        public void FlushContext()
        {
            ResetContext();
        }

        #endregion

        private sealed class EntityRepository<T> : Repository<T> where T : class
        {
            private readonly DbContext _dbContext;
            private readonly DbSet<T> _dbSet;

            public EntityRepository(DbContext dbContext, DbSet<T> dbSet)
                : base(dbSet)
            {
                _dbContext = dbContext;
                _dbSet = dbSet;
            }

            public override void AddObject(T entity)
            {
                _dbSet.Add(entity);
            }

            public override void AddObjects(IEnumerable<T> entities)
            {
                _dbSet.AddRange(entities);
            }

            public override void DeleteObject(T entity)
            {
                _dbSet.Remove(entity);
            }

            public override void ReloadObject(T entity)
            {
                _dbContext.Entry(entity).Reload();
            }

            public override T FindById(decimal id)
            {
                return _dbSet.Find(id);
            }

            public override void DeleteObjects(IEnumerable<T> entities)
            {
                _dbSet.RemoveRange(entities);
            }
        }
    }
}
