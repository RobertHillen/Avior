using System;
using Avior.Base.Interfaces;
using Avior.Database.Models;

namespace Avior.Business.UnitOfWork
{
    public interface IDataUnitOfWork : IUnitOfWork
    {
        Repository<Coach> Coaches { get; }

        Repository<Player> Players { get; }

        Repository<Team> Teams { get; }

        void ExecuteWithoutChangeTracking(Action action);
    }
}
