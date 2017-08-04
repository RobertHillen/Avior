using System.Linq;
using Avior.Base.Interfaces;
using Avior.Business.EntityConversions;
using Avior.Business.UnitOfWork;
using Avior.Business.Views.Coach;

namespace Avior.Business.Queries.Coach
{
    public sealed class GetCoachListQuery: IQuery<IQueryable<CoachDetailView>>
    {
    }

    public sealed class GetCoachListQueryHandler : IQueryHandler<GetCoachListQuery, IQueryable<CoachDetailView>>
    {
        private readonly IDataUnitOfWork _uow;

        public GetCoachListQueryHandler(IDataUnitOfWork uow)
        {
            _uow = uow;
        }

        public IQueryable<CoachDetailView> Handle(GetCoachListQuery parameters)
        {
            var teams = (from t in _uow.Teams
                         select t).ToTeamListView().ToList();

            var coaches = (from c in _uow.Coaches
                           select c).ToCoachListView().ToList();

            foreach (var coach in coaches)
            {
                coach.Team = (from t in teams
                              where t.ID == coach.Team.ID
                              select t).SingleOrDefault();
            }
            
            return coaches.OrderBy(m => m.Team.Name)
                          .AsQueryable();
        }
    }
}