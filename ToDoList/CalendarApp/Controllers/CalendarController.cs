using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CalendarApp.ExtensionMethods;
using CalendarApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace CalendarApp.Controllers
{
    public class CalendarController : Controller
    {
        [HttpGet]
        public IActionResult Month(DateTime? datetime)
        {
            DateTime dt;
            if (!datetime.HasValue)
                dt = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            else
                dt = new DateTime(datetime.Value.Year, datetime.Value.Month, 1);

            var daysinmonth = DateTime.DaysInMonth(dt.Year, dt.Month);

            var monthDto = new MonthViewModel()
            {
                Month = dt.Month,
                Year = dt.Year,
                StartDay = dt.DayOfWeek,
                DaysInMonth = daysinmonth,
                LastMonthDaysInMonth = DateTime.DaysInMonth(dt.Year, dt.Subtract(new TimeSpan(1, 0, 0, 0)).Month),
                LastMonth = dt.Subtract(new TimeSpan(1, 0, 0, 0)),
                NextMonth = dt.Add(new TimeSpan(daysinmonth, 0, 0, 0))
            };

            return View(monthDto);
        }

        [HttpGet]
        public IActionResult Week(DateTime? dateTime)
        {
            if (!dateTime.HasValue)
                dateTime = DateTime.Now;

            var startofweek = dateTime.Value.FirstDayOfWeek();
            var endofweek = dateTime.Value.LastDayOfWeek();

            var weekDto = new WeekViewModel()
            {
                StartDate = startofweek,
                EndDate = endofweek,
                LastWeek = startofweek.Subtract(new TimeSpan(7,0,0,0)),
                NextWeek = endofweek.Add(new TimeSpan(7,0,0,0))
            };          

            return View(weekDto);
        }
    }
}