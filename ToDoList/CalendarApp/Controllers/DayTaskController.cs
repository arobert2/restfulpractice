using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Services;

namespace ToDoList.Controllers
{
    [Route("api/Day")]
    public class DayTaskController : Controller
    {
        private readonly IToDoRepository _toDoRepository;

        public DayTaskController(IToDoRepository toDoRepository)
        {
            _toDoRepository = toDoRepository;
        }

        [HttpGet("{id}")]
        public IActionResult GetDay(Guid id)
        {
            var daysFromRepo = _toDoRepository.GetDay(id);

            if (daysFromRepo == null)
                return NotFound();

            return Ok(daysFromRepo);
        }
        [HttpGet("{start}/{end}")]
        public IActionResult GetDays(DateTime start, DateTime end)
        {
            var daysFromRepo = _toDoRepository.GetDays(start, end);

            if (daysFromRepo == null)
                return NotFound();

            return Ok(daysFromRepo);
        }
    }
}