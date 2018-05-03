using System.ComponentModel.DataAnnotations;
using System.Linq;
using Avior.Base.Interfaces;
using Avior.Business.EntityConversions;
using Avior.Business.UnitOfWork;
using Avior.Business.Views.Team;

namespace Avior.Business.Queries.Team
{
    public sealed class GetTeamDetailsQuery : IQuery<TeamDetailView>
    {
        [Required]
        public int Id { get; set; }
    }

    public sealed class GetTeamDetailsQueryHandler : IQueryHandler<GetTeamDetailsQuery, TeamDetailView>
    {
        private readonly IDataUnitOfWork _uow;

        public GetTeamDetailsQueryHandler(IDataUnitOfWork uow)
        {
            _uow = uow;
        }

        public TeamDetailView Handle(GetTeamDetailsQuery parameters)
        {
            var team = (from t in _uow.Teams
                        where t.Id == parameters.Id
                        select t).SingleOrDefault().ToTeamDetailView();

            return team;
        }
    }
}
