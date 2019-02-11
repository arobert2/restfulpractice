using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoList.Services;

namespace ToDoList.Controllers
{
    [Route("Home/{action}")]
    public class HomeController : Controller
    {
        private readonly IToDoRepository _toDoRepository;

        public HomeController(IToDoRepository toDoRepository)
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
