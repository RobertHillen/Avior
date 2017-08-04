using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Avior.Database.Models;

namespace Avior.Business.UnitOfWork
{
    internal class DataUnitOfWork : IDataUnitOfWork
    {
        private readonly IRepositoryMapper mapper;

        public DataUnitOfWork(IRepositoryMapper mapper)
        {
            this.mapper = mapper;
        }

        public Repository<Coach> Coaches
        {
            get { return mapper.GetRepository<Coach>(); }
        }

        public Repository<Player> Players
        {
            get { return mapper.GetRepository<Player>(); }
        }
        public Repository<Team> Teams
        {
            get { return mapper.GetRepository<Team>(); }
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
