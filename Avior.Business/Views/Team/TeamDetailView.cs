using System;
using Avior.Base.Enums;
using System.Globalization;

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
            var culture = new CultureInfo("nl-NL");

            return $"{culture.DateTimeFormat.GetDayName(TrainingDay1)} {TrainingTime1.ToString(@"hh\.mm")}";
        }

        public string Training2()
        {
            if (TrainingDay2 != null)
            {
                var culture = new CultureInfo("nl-NL");
                var t = ((TimeSpan)TrainingTime2).ToString(@"hh\.mm");

                return $"{culture.DateTimeFormat.GetDayName((DayOfWeek)TrainingDay2)} {((TimeSpan)TrainingTime2).ToString(@"hh\.mm")}";
            }
            else
                return string.Empty;
        }

    }
}
