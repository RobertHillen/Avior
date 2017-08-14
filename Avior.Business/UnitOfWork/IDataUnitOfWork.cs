using System;
using Avior.Base.Interfaces;
using Avior.Database.Entity;

namespace Avior.Business.UnitOfWork
{
    public interface IDataUnitOfWork : IUnitOfWork
    {
        Repository<Coaches> Coaches { get; }

        Repository<Players> Players { get; }

        Repository<Teams> Teams { get; }

        void ExecuteWithoutChangeTracking(Action action);
    }
}
