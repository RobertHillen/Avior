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
            var coaches = (from c in _uow.Coaches
                           select c).ToCoachListView().ToList();

            return coaches.OrderBy(m => m.Team.Name)
                          .ThenBy(m => m.Name)  
                          .AsQueryable();
        }
    }
}