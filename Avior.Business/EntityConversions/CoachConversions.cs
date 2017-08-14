using System;
using System.Linq;
using Avior.Base;
using Avior.Base.Enums;
using Avior.Business.Commands.Coach;
using Avior.Business.Views.Coach;
using Avior.Business.Views.Team;
using Avior.Database.Entity;

namespace Avior.Business.EntityConversions
{
    internal static class CoachConversions
    {
        internal static IQueryable<CoachDetailView> ToCoachListView(this IQueryable<Coaches> coaches)
        {
            return from coach in coaches
                select new CoachDetailView
                {
                    ID = coach.ID,
                    Name = coach.Name,
                    Email = coach.Email,
                    PhoneNumber = coach.PhoneNumber,
                    Team = new TeamDetailView
                           {
                                    ID = coach.Team.ID,
                                    Season = (enuSeason)coach.Team.Season,
                                    Category = (enuCategory)coach.Team.Category,
                                    Name = coach.Team.Name,
                                    TrainingDay1 = (DayOfWeek)coach.Team.TrainingDay1,
                                    TrainingTime1 = coach.Team.TrainingTime1,
                                    TrainingDay2 = (DayOfWeek)coach.Team.TrainingDay2,
                                    TrainingTime2 = coach.Team.TrainingTime2
                           }
                };
        }

        internal static CoachDetailView ToCoachDisplayView(this Coaches coach)
        {
            return new CoachDetailView()
            {
                ID = coach.ID,
                Name = coach.Name,
                Email = coach.Email,
                PhoneNumber = coach.PhoneNumber,
                Team = coach.Team.ToTeamDetailView()
            };
        }

        internal static EditCoachCommand ToEditCoachCommand(this Coaches coach)
        {
            return new EditCoachCommand
            {
                ID = coach.ID,
                Name = coach.Name,
                Email = coach.Email,
                PhoneNumber = coach.PhoneNumber,
                TeamID = coach.Team == null ? Constants.Invalid_Id : coach.Team.ID
            };
        }
    }
}
