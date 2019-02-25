using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CalendarApp.Models;
using CalendarApp.Services;
using Microsoft.AspNetCore.Mvc;
using CalendarApp.Entities;

namespace CalendarApp.Controllers
{
    [Route("/api/events")]
    public class EventController : Controller
    {
        private readonly ICalendarEventRepository _calendarRepository;

        public EventController(ICalendarEventRepository calendarRepository)
        {
            _calendarRepository = calendarRepository;
        }

        [HttpGet("{datetime}")]
        public IActionResult GetDayEvents(DateTime datetime)
        {
            var eventsFromRepository = _calendarRepository.GetEvents(datetime, datetime.Add(new TimeSpan(23, 59, 59)));
            if (eventsFromRepository.Count() == 0)
                return NotFound();

            return Ok(eventsFromRepository);
        }

        [HttpGet("{start}/{end}")]
        public IActionResult GetEvents(DateTime start, DateTime end)
        {
            var eventsFromRepository = _calendarRepository.GetEvents(start, end);
            if (eventsFromRepository.Count() == 0)
                return NotFound();

            return Ok(eventsFromRepository);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteEvent(Guid id)
        {
            var eventFromRepository = _calendarRepository.GetEvent(id);
            if (eventFromRepository == null)
                return NotFound();

            _calendarRepository.DeleteEvent(eventFromRepository);
            if (!_calendarRepository.Save())
                throw new Exception("Failed to delete EventEntity on save.");

            return NoContent();
        }
        [HttpPost]
        public IActionResult ScheduleEvent([FromBody] EventDto eventDto)
        {
            return Ok();
        }
    }
}