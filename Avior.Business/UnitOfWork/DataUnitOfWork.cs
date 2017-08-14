using System;
using Avior.Database.Entity;

namespace Avior.Business.UnitOfWork
{
    internal class DataUnitOfWork : IDataUnitOfWork
    {
        private readonly IRepositoryMapper mapper;

        public DataUnitOfWork(IRepositoryMapper mapper)
        {
            this.mapper = mapper;
        }

        public Repository<Coaches> Coaches
        {
            get { return mapper.GetRepository<Coaches>(); }
        }

        public Repository<Players> Players
        {
            get { return mapper.GetRepository<Players>(); }
        }
        public Repository<Teams> Teams
        {
            get { return mapper.GetRepository<Teams>(); }
        }

        public void SaveChanges()
        {
            mapper.Save();
        }

        public bool HasChanges()
        {
            return mapper.HasChanges();
        }

        public void ExecuteWithoutChangeTracking(Action action)
        {
            mapper.AutoDetectChanges(false);

            try
            {
                action();
            }
            finally
            {
                mapper.AutoDetectChanges(true);
            }
        }

        public void Dispose()
        {
            if (mapper != null)
            {
                mapper.Dispose();
            }
        }
    }
}
