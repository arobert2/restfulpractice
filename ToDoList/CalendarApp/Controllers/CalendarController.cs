using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CalendarApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace CalendarApp.Controllers
{
    public class CalendarController : Controller
    {/*
        [HttpGet]
        public IActionResult Index()
        {
            var monthDto = new MonthDto()
            {
                Month = DateTime.Now.Month,
                Year = DateTime.Now.Year,
                StartDay = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).DayOfWeek,
                DaysInMonth = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month),
                LastMonthDaysInMonth = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month - 1 == 0 ? 12 : DateTime.Now.Month - 1),
                NextMonthDaysInMonth = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month + 1 == 13 ? 1 : DateTime.Now.Month + 1)
            };

            return View(monthDto);
        }*/

        [HttpGet]
        public IActionResult Index(int month, int year)
        {
            DateTime datetime;

            if (month <= 0 && year <= 0)
                datetime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            else
                datetime = new DateTime(year, month, 1);

            var monthDto = new MonthDto()
            {
                Month = datetime.Month,
                Year = datetime.Year,
                StartDay = datetime.DayOfWeek,
                DaysInMonth = DateTime.DaysInMonth(datetime.Year, datetime.Month),
                LastMonthDaysInMonth = DateTime.DaysInMonth(datetime.Year, datetime.Month - 1 == 0 ? 12 : datetime.Month - 1),
                NextMonthDaysInMonth = DateTime.DaysInMonth(datetime.Year, datetime.Month + 1 == 13 ? 1 : datetime.Month + 1),

                LastMonth = new DateTime(datetime.Month - 1 == 0 ? datetime.Year - 1 : datetime.Year, datetime.Month - 1 == 0 ? 12 : datetime.Month - 1, 1),
                NextMonth = new DateTime(datetime.Month + 1 == 13 ? datetime.Year + 1 : datetime.Year, datetime.Month + 1 == 13 ? 1 : datetime.Month + 1, 1)
            };

            return View(monthDto);
        }
    }
}