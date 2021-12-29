using System;
using System.Globalization;

namespace Avior.Business.Helpers
{
    public static class TeamHelper
    {
        public static string TrainingDayTime(DayOfWeek? day, TimeSpan? time, string location)
        {
            if (day != null)
            {
                var culture = new CultureInfo("nl-NL");
                var t = ((TimeSpan)time).ToString(@"hh\.mm");

                return $"{culture.DateTimeFormat.GetDayName((DayOfWeek)day)} {((TimeSpan)time).ToString(@"hh\.mm")} {location}";
            }
            else
                return string.Empty;
        }
    }
}
