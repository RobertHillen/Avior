using System;
using Avior.Business.Helpers;
using Avior.Business.Views.Team;
using Avior.Database.Entity;

namespace Avior.Business.Views.Coach
{
    public class CoachDetailView
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public TeamDetailView Team { get; set; }

        public Players[] Players { get; set; }

        public string Training1()
        {
            if (Team != null)
            {
                return TeamHelper.TrainingDayTime((DayOfWeek)Team.TrainingDay1, Team.TrainingTime1);
            }
            else
                return string.Empty;
        }

        public string Training2()
        {
            if (Team != null)
            {
                return TeamHelper.TrainingDayTime((DayOfWeek)Team.TrainingDay2, Team.TrainingTime2);
            }
            else
                return string.Empty;
        }
    }
}
