using System;
using Avior.Base.Enums;
using Avior.Base.Helpers;
using Avior.Business.Helpers;

namespace Avior.Business.Views.Team
{
    public class TeamView
    {
        public int Id { get; set; }

        public enuSeason Season { get; set; }

        public enuCategory Category { get; set; }

        public string Name { get; set; }

        public DayOfWeek TrainingDay1 { get; set; }

        public TimeSpan TrainingTime1 { get; set; }

        public string TrainingLocation1 { get; set; }

        public DayOfWeek? TrainingDay2 { get; set; }

        public TimeSpan? TrainingTime2 { get; set; }

        public string TrainingLocation2 { get; set; }

        public string Training1()
        {
            return TeamHelper.TrainingDayTime(TrainingDay1, TrainingTime1, TrainingLocation1);
        }

        public string Training2()
        {
            return TeamHelper.TrainingDayTime(TrainingDay2, TrainingTime2, TrainingLocation2);
        }

        public string SeasonToString()
        {
            return Season.GetDisplayName();
        }

        public string CategoryToString()
        {
            return Category.GetDisplayName();
        }
    }
}
