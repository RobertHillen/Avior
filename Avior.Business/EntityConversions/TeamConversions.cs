using Avior.Base.Enums;
using Avior.Business.Views.Team;
using Avior.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avior.Business.EntityConversions
{
    internal static class TeamConversions
    {
        internal static IQueryable<TeamDetailView> ToTeamListView(this IQueryable<Team> teams)
        {
            return from team in teams
                   select new TeamDetailView
                   {
                       ID = team.ID,
                       Season = team.Season,
                       Category = team.Category,
                       Name = team.Name,
                       TrainingDay1 = team.TrainingDay1,
                       TrainingTime1 = team.TrainingTime1,
                       TrainingDay2 = team.TrainingDay2,
                       TrainingTime2 = team.TrainingTime2
                   };
        }

        internal static TeamDetailView ToTeamDisplayView(this Team team)
        {
            return new TeamDetailView
            {
                ID = team.ID,
                Season = team.Season,
                Category = team.Category,
                Name = team.Name,
                TrainingDay1 = team.TrainingDay1,
                TrainingTime1 = team.TrainingTime1,
                TrainingDay2 = team.TrainingDay2,
                TrainingTime2 = team.TrainingTime2
            };
        }
    }
}
