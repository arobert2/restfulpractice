using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalendarApp.Models
{
    public class MonthViewModel
    {
        public int Month { get; set; }
        public int Year { get; set; }
        public int DaysInMonth { get; set; }
        public int LastMonthDaysInMonth { get; set; }
        public int NextMonthDaysInMonth { get; set; }
        public DayOfWeek StartDay { get; set; }

        public DateTime LastMonth { get; set; }
        public DateTime NextMonth { get; set; }
    }
}
