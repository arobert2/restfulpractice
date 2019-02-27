using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CalendarApp.Models;
using CalendarApp.Services;
using Microsoft.AspNetCore.Mvc;
using CalendarApp.Entities;
using AutoMapper;

namespace CalendarApp.Controllers
{

    public class EventController : Controller
    {
        private readonly ICalendarEventRepository _calendarRepository;


        public EventController(ICalendarEventRepository calendarRepository)
        {
            _calendarRepository = calendarRepository;
        }
        [HttpGet("{id}")]
        public IActionResult GetEvent(Guid id)
        {
            var eventFromRepo = _calendarRepository.GetEvent(id);
            if (eventFromRepo == null)
                return NotFound();
            var eventFromMap = Mapper.Map<CalendarEventDto>(eventFromRepo);
            return Ok(eventFromRepo);
        }
        [HttpGet("{datetime}")]
        public IActionResult GetEvents(DateTime datetime)
        {
            var eventsFromRepository = _calendarRepository.GetEvents(datetime, datetime.Add(new TimeSpan(23, 59, 59)));
            if (eventsFromRepository.Count() == 0)
                return NotFound();

            var eventsdtomap = Mapper.Map<IEnumerable<CalendarEventDto>>(eventsFromRepository);

            return Ok(eventsdtomap);
        }
        [HttpGet("{start}/{end}")]
        public IActionResult GetEvents(DateTime start, DateTime end)
        {
            var eventsFromRepository = _calendarRepository.GetEvents(start, end);
            if (eventsFromRepository.Count() == 0)
                return NotFound();

            var eventsdtomap = Mapper.Map<IEnumerable<CalendarEventDto>>(eventsFromRepository);

            return Ok(eventsdtomap);
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
        public IActionResult ScheduleEvent([FromBody] ScheduleCalendarEventDto scheduleCalendarEventDto)
        {
            if (scheduleCalendarEventDto == null)
                return BadRequest();

            var eventEntityMap = Mapper.Map<CalendarEvent>(scheduleCalendarEventDto);
            _calendarRepository.AddEvent(eventEntityMap);
            if (!_calendarRepository.Save())
                throw new Exception("Failed to create event on save.");
            return CreatedAtRoute("GeEvent", new { id = eventEntityMap.Id }, eventEntityMap);
        }
        [HttpPatch]
        public IActionResult UpdateEvent(Guid id, [FromBody] UpdateCalendarEventDto updateCalendarEventDto)
        {
            return Ok();
        }
    }
}