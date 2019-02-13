using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CalendarApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace CalendarApp.Controllers
{
    public class CalendarController : Controller
    {
        public IActionResult Calendar()
        {
            var monthDto = new MonthDto()
            {
                Month = DateTime.Now.Month,
                Year = DateTime.Now.Year,
                StartDay = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).DayOfWeek,
                DaysInMonth = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month)
            };

            return View(monthDto);
        }
    }
}