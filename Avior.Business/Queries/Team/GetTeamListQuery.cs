using System.Linq;
using Avior.Base.Interfaces;
using Avior.Business.EntityConversions;
using Avior.Business.UnitOfWork;
using Avior.Business.Views.Team;

namespace Avior.Business.Queries.Team
{
    public sealed class GetTeamListQuery : IQuery<IQueryable<TeamDetailView>>
    {
    }

    public sealed class GetTeamListQueryHandler : IQueryHandler<GetTeamListQuery, IQueryable<TeamDetailView>>
    {
        private readonly IDataUnitOfWork _uow;

        public GetTeamListQueryHandler(IDataUnitOfWork uow)
        {
            _uow = uow;
        }

        public IQueryable<TeamDetailView> Handle(GetTeamListQuery parameters)
        {
            var teams = (from t in _uow.Teams
                         select t).ToTeamListView().ToList();

            return teams.OrderByDescending(m => m.Season)
                        .ThenBy(m => m.Name)
                        .AsQueryable();
        }
    }
}