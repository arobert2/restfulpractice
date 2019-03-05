using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CalendarApp.ExtensionMethods;
using CalendarApp.Models;
using CalendarApp.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CalendarApp.Controllers
{
    public class CalendarController : Controller
    {
        /// <summary>
        /// Returns a view that renders a monthly calendar
        /// </summary>
        /// <param name="datetime"></param>
        /// <returns>View</returns>
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
        /// <summary>
        /// Returns a view that renders a weekly planner
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Returns a Day view
        /// </summary>
        /// <param name="datetime">datetime object of day.</param>
        /// <returns>View of the day</returns>
        [HttpGet]
        public IActionResult Day(DateTime? datetime)
        {
            DateTime dateTimeFromInput;
            if (datetime == null)
                dateTimeFromInput = DateTime.Now;
            else
                dateTimeFromInput = datetime.Value;

            return View(dateTimeFromInput);
        }
    }
}