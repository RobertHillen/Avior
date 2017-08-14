using System;
using Avior.Base.Enums;
using Avior.Business.Helpers;

namespace Avior.Business.Views.Team
{
    public class TeamDetailView
    {
        public int ID { get; set; }

        public enuSeason Season { get; set; }

        public enuCategory Category { get; set; }

        public string Name { get; set; }

        public DayOfWeek TrainingDay1 { get; set; }

        public TimeSpan TrainingTime1 { get; set; }

        public DayOfWeek? TrainingDay2 { get; set; }

        public TimeSpan? TrainingTime2 { get; set; }

        public string Training1()
        {
            return TeamHelpers.TrainingDayTime(TrainingDay1, TrainingTime1);
        }

        public string Training2()
        {
            return TeamHelpers.TrainingDayTime(TrainingDay2, TrainingTime2);
        }
    }
}
