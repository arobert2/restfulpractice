using CalendarApp.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalendarApp.Models.ViewModels
{
    public class MonthViewModel
    {
        public int Month { get; set; }
        public int Year { get; set; }
        public int DaysInMonth { get; set; }
        public int LastMonthDaysInMonth { get; set; }
        public DayOfWeek StartDay { get; set; }
        public DateTime LastMonth { get; set; }
        public DateTime NextMonth { get; set; }

        public string HeaderText => System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(Month) + " " + Year;

        public List<CalendarEventDto> ScheduledEvents { get; set; } = new List<CalendarEventDto>();
    }
}
