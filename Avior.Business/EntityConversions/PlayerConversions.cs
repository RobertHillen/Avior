using System;
using System.Linq;
using Avior.Base;
using Avior.Base.Enums;
using Avior.Business.Commands.Player;
using Avior.Business.Views.Player;
using Avior.Business.Views.Team;
using Avior.Database.Entity;

namespace Avior.Business.EntityConversions
{
    internal static class PlayerConversions
    {
        internal static IQueryable<PlayerDetailView> ToPlayerListView(this IQueryable<Players> players)
        {
            return from player in players
                   select new PlayerDetailView
                   {
                       ID = player.ID,
                       Name = player.Name,
                       PhoneNumber = player.PhoneNumber,
                       Team = new TeamDetailView
                       {
                           ID = player.Team.ID,
                           Season = (enuSeason)player.Team.Season,
                           Category = (enuCategory)player.Team.Category,
                           Name = player.Team.Name,
                           TrainingDay1 = (DayOfWeek)player.Team.TrainingDay1,
                           TrainingTime1 = player.Team.TrainingTime1,
                           TrainingDay2 = (DayOfWeek)player.Team.TrainingDay2,
                           TrainingTime2 = player.Team.TrainingTime2
                       }
                   };
        }

        internal static PlayerDetailView ToPlayerDisplayView(this Players player)
        {
            return new PlayerDetailView()
            {
                ID = player.ID,
                Name = player.Name,
                PhoneNumber = player.PhoneNumber,
                Team = player.Team.ToTeamDetailView()
            };
        }

        internal static EditPlayerCommand ToEditPlayerCommand(this Players player)
        {
            return new EditPlayerCommand
            {
                ID = player.ID,
                Name = player.Name,
                PhoneNumber = player.PhoneNumber,
                TeamID = player.Team == null ? Constants.Invalid_Id : player.Team.ID
            };
        }
    }
}
