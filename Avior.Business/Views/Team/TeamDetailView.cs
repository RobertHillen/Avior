using System;
using Avior.Base.Enums;
using Avior.Business.Helpers;
using Avior.Database.Entity;

namespace Avior.Business.Views.Team
{
    public class TeamDetailView
    {
        public int Id { get; set; }

        public enuSeason Season { get; set; }

        public enuCategory Category { get; set; }

        public string Name { get; set; }

        public DayOfWeek TrainingDay1 { get; set; }

        public TimeSpan TrainingTime1 { get; set; }

        public DayOfWeek? TrainingDay2 { get; set; }

        public TimeSpan? TrainingTime2 { get; set; }

        public Coaches[] Coaches { get; set; }

        public Players[] Players { get; set; }

        public string Training1()
        {
            return TeamHelper.TrainingDayTime(TrainingDay1, TrainingTime1);
        }

        public string Training2()
        {
            return TeamHelper.TrainingDayTime(TrainingDay2, TrainingTime2);
        }
    }
}
