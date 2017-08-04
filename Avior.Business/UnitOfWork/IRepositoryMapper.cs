using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avior.Business.UnitOfWork
{
    public interface IRepositoryMapper : IDisposable
    {
        Repository<T> GetRepository<T>() where T : class;

        void Save();

        bool HasChanges();

        void AutoDetectChanges(bool enabled);

        void FlushContext();
    }
}