using System;

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