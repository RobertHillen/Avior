using System;
using System.Collections.Generic;
using Avior.Base.Enums;
using System.ComponentModel.DataAnnotations;

namespace Avior.Database.Models
{
    public class Team
    {
        public int ID { get; set; }

        [Required]
        public enuSeason Season { get; set; }

        [Required]
        public enuCategory Category { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; }

        public DayOfWeek TrainingDay1 { get; set; }

        public TimeSpan TrainingTime1 { get; set; }

        public DayOfWeek? TrainingDay2 { get; set; }

        public TimeSpan? TrainingTime2 { get; set; }

        public ICollection<Player> Players { get; set; }

        public ICollection<Coach> Coaches { get; set; }
    }
}
