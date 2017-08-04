using System;
using System.Collections.Generic;
using Avior.Base.Enums;

namespace Avior.Database.Models
{
    public class Team
    {
        public int ID { get; set; }
        public enuSeason Season { get; set; }
        public enuCategory Category { get; set; }
        public string Name { get; set; }
        public DayOfWeek TrainingDay1 { get; set; }
        public TimeSpan TrainingTime1 { get; set; }
        public DayOfWeek? TrainingDay2 { get; set; }
        public TimeSpan? TrainingTime2 { get; set; }

        public ICollection<Player> Players { get; set; }
        public ICollection<Coach> Coaches { get; set; }
    }
}
