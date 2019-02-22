using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalendarApp.ExtensionMethods
{
    public static class DateTimeExtensions
    {
        public static DateTime FirstDayOfWeek(this DateTime dateTime)
        {
            if (dateTime.DayOfWeek == DayOfWeek.Sunday)
                return dateTime;

            var weekindex = (int)dateTime.DayOfWeek;
            var sunday = dateTime.Subtract(new TimeSpan(weekindex, 0, 0, 0));
            return sunday;
        }

        public static DateTime LastDayOfWeek(this DateTime dateTime)
        {
            if (dateTime.DayOfWeek == DayOfWeek.Friday)
                return dateTime;

            var weekindex = (int)dateTime.DayOfWeek;
            var saturday = dateTime.Add(new TimeSpan(6 - weekindex, 0, 0, 0));
            return saturday;
        }
    }
}
