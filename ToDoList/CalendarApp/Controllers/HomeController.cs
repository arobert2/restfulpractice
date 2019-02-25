using CalendarApp.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoList.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICalendarEventRepository _toDoRepository;

        public HomeController(ICalendarEventRepository toDoRepository)
        {
            _toDoRepository = toDoRepository;
        }

        public IActionResult Index()
        {
            var date = DateTime.Now.Date;

            return View();
        }
    }
}
