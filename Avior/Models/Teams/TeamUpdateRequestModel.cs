using Avior.Base.Enums;
using System;

namespace Avior.Models.Teams
{
    public class TeamUpdateRequestModel
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
    }
}