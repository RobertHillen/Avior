using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Avior.Base.Interfaces;
using Avior.Business.EntityConversions;
using Avior.Business.UnitOfWork;
using Avior.Business.Views.Coach;
using Avior.Business.Views.Player;

namespace Avior.Business.Queries.Coach
{
    public sealed class GetCoachDetailsQuery : IQuery<CoachDetailView>
    {
        [Required]
        public int Id { get; set; }
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
                         where c.Id == parameters.Id
                         select c).SingleOrDefault().ToCoachDetailView();

            var players = (from p in _uow.Players
                           where p.TeamId == coach.Team.Id
                           orderby p.Name
                           select p);
            var playerList = new List<PlayerView>();
            foreach (var player in players)
            {
                playerList.Add(player.ToPlayerView());
            }
            coach.Players = playerList.ToArray();

            return coach;
        }
    }
}
