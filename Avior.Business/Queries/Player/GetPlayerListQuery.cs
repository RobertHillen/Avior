using System.Linq;
using Avior.Base.Interfaces;
using Avior.Business.EntityConversions;
using Avior.Business.UnitOfWork;
using Avior.Business.Views.Player;

namespace Avior.Business.Queries.Player
{
    public class GetPlayerListQuery : IQuery<IQueryable<PlayerDetailView>>
    {
    }

    public sealed class GetPlayerListQueryHandler : IQueryHandler<GetPlayerListQuery, IQueryable<PlayerDetailView>>
    {
        private readonly IDataUnitOfWork _uow;

        public GetPlayerListQueryHandler(IDataUnitOfWork uow)
        {
            _uow = uow;
        }

        public IQueryable<PlayerDetailView> Handle(GetPlayerListQuery parameters)
        {
            var players = (from p in _uow.Players
                           select p).ToPlayerListView().ToList();

            return players.OrderBy(m => m.Team.Name)
                          .ThenBy(m => m.Name)
                          .AsQueryable();
        }
    }
}