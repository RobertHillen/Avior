using System;
using System.Linq;
using Avior.Base.Enums;
using Avior.Business.Views.Team;
using Avior.Database.Entity;

namespace Avior.Business.EntityConversions
{
    internal static class TeamConversions
    {
        internal static IQueryable<TeamHtmlSelectView> ToTeamHtmlSelectView(this IQueryable<Teams> teams)
        {
            return from team in teams
                   orderby team.Name
                   select new TeamHtmlSelectView
                   {
                       Key = team.Name,
                       Value = team.ID
                   };
        }

        internal static IQueryable<TeamDetailView> ToTeamListView(this IQueryable<Teams> teams)
        {
            return from team in teams
                   select new TeamDetailView
                   {
                       ID = team.ID,
                       Season = (enuSeason)team.Season,
                       Category = (enuCategory)team.Category,
                       Name = team.Name,
                       TrainingDay1 = (DayOfWeek)team.TrainingDay1,
                       TrainingTime1 = team.TrainingTime1,
                       TrainingDay2 = (DayOfWeek)team.TrainingDay2,
                       TrainingTime2 = team.TrainingTime2
                   };
        }

        internal static TeamDetailView ToTeamDetailView(this Teams team)
        {
            return new TeamDetailView
            {
                ID = team.ID,
                Season = (enuSeason)team.Season,
                Category = (enuCategory)team.Category,
                Name = team.Name,
                TrainingDay1 = (DayOfWeek)team.TrainingDay1,
                TrainingTime1 = team.TrainingTime1,
                TrainingDay2 = team.TrainingDay2 == null ? null : (DayOfWeek?)team.TrainingDay2,
                TrainingTime2 = team.TrainingTime2
            };
        }
    }
}
