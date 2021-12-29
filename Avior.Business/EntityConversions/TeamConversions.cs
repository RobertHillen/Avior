using System;
using System.Linq;
using Avior.Base.Enums;
using Avior.Business.Commands.Team;
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
                       
                       Key = team.Name + "(" + team.Season.ToString() + ")",
                       Value = team.Id
                   };
        }

        internal static IQueryable<TeamDetailView> ToTeamListView(this IQueryable<Teams> teams)
        {
            return from team in teams
                select new TeamDetailView
                {
                    Id = team.Id,
                    Season = (enuSeason)team.Season,
                    Category = (enuCategory)team.Category,
                    Name = team.Name,
                    TrainingDay1 = (DayOfWeek)team.TrainingDay1,
                    TrainingTime1 = team.TrainingTime1,
                    TrainingLocation1 = team.TrainingLocation1,
                    TrainingDay2 = (DayOfWeek?)team.TrainingDay2,
                    TrainingTime2 = team.TrainingTime2,
                    TrainingLocation2 = team.TrainingLocation2
                };
        }

        internal static TeamDetailView ToTeamDetailView(this Teams team)
        {
            return new TeamDetailView
            {
                Id = team.Id,
                Season = (enuSeason)team.Season,
                Category = (enuCategory)team.Category,
                Name = team.Name,
                TrainingDay1 = (DayOfWeek)team.TrainingDay1,
                TrainingTime1 = team.TrainingTime1,
                TrainingLocation1 = team.TrainingLocation1,
                TrainingDay2 = (DayOfWeek?)team.TrainingDay2,
                TrainingTime2 = team.TrainingTime2,
                TrainingLocation2 = team.TrainingLocation2,
                Coaches = team.Coaches.ToArray(),
                Players = team.Players.ToArray()
            };
        }

        internal static TeamView ToTeamView(this Teams team)
        {
            return new TeamView
            {
                Id = team.Id,
                Season = (enuSeason)team.Season,
                Category = (enuCategory)team.Category,
                Name = team.Name,
                TrainingDay1 = (DayOfWeek)team.TrainingDay1,
                TrainingTime1 = team.TrainingTime1,
                TrainingLocation1 = team.TrainingLocation1,
                TrainingDay2 = (DayOfWeek?)team.TrainingDay2,
                TrainingTime2 = team.TrainingTime2,
                TrainingLocation2 = team.TrainingLocation2,
            };
        }

        internal static EditTeamCommand ToEditTeamCommand(this Teams team)
        {
            return new EditTeamCommand
            {
                Id = team.Id,
                Season = (enuSeason)team.Season,
                Category = (enuCategory)team.Category,
                Name = team.Name,
                TrainingDay1 = (DayOfWeek)team.TrainingDay1,
                TrainingTime1 = team.TrainingTime1,
                TrainingLocation1 = team.TrainingLocation1,
                TrainingDay2 = (DayOfWeek?)team.TrainingDay2,
                TrainingTime2 = team.TrainingTime2,
                TrainingLocation2 = team.TrainingLocation2,
            };
        }
    }
}
