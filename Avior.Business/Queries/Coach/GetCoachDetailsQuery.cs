using System.ComponentModel.DataAnnotations;
using System.Linq;
using Avior.Base.Interfaces;
using Avior.Business.EntityConversions;
using Avior.Business.UnitOfWork;
using Avior.Business.Views.Coach;

namespace Avior.Business.Queries.Coach
{
    public sealed class GetCoachDetailsQuery : IQuery<CoachDetailView>
    {
        [Required]
        public int ID { get; set; }
    }

    public sealed class GetCoachDetailsQueryHandler : IQueryHandler<GetCoachDetailsQuery, CoachDetailView>
    {
        private readonly IDataUnitOfWork _uow;

        public GetCoachDetailsQueryHandler(IDataUnitOfWork uow)
        {
            _uow = uow;
        }

        public CoachDetailView Handle(GetCoachDetailsQuery parameters)
        {
            var coach = (from c in _uow.Coaches
                         where c.ID == parameters.ID
                         select c).SingleOrDefault().ToCoachDisplayView();

            coach.Players = (from p in _uow.Players
                             where p.TeamID == coach.Team.ID
                             orderby p.Name
                             select p).ToArray();

            return coach;
        }
    }
}
