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
    [Route("/api/events")]
    public class EventController : Controller
    {
        private readonly ICalendarEventRepository _calendarRepository;

        public EventController(ICalendarEventRepository calendarRepository)
        {
            _calendarRepository = calendarRepository;
        }
        [HttpGet("{id}", Name="GetEvent")]
        public IActionResult GetEvent(Guid id)
        {
            var eventFromRepo = _calendarRepository.GetEvent(id);
            if (eventFromRepo == null)
                return NotFound();
            var eventFromMap = Mapper.Map<EventDto>(eventFromRepo);
            return Ok(eventFromRepo);
        }

        [HttpGet("/day/{datetime}")]
        public IActionResult GetDayEvents(DateTime datetime)
        {
            var eventsFromRepository = _calendarRepository.GetEvents(datetime, datetime.Add(new TimeSpan(23, 59, 59)));
            if (eventsFromRepository.Count() == 0)
                return NotFound();

            var eventsdtomap = Mapper.Map <IEnumerable<EventDto>>(eventsFromRepository);

            return Ok(eventsdtomap);
        }

        [HttpGet("{start}/{end}")]
        public IActionResult GetEvents(DateTime start, DateTime end)
        {
            var eventsFromRepository = _calendarRepository.GetEvents(start, end);
            if (eventsFromRepository.Count() == 0)
                return NotFound();

            var eventsdtomap = Mapper.Map<IEnumerable<EventDto>>(eventsFromRepository);

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
        public IActionResult ScheduleEvent([FromBody] ScheduleEventDto scheduleEventDto)
        {
            if (scheduleEventDto == null)
                return BadRequest();

            var eventEntityMap = Mapper.Map<TaskEntity>(scheduleEventDto);
            _calendarRepository.AddEvent(eventEntityMap);
            if (!_calendarRepository.Save())
                throw new Exception("Failed to create event on save.");
            return CreatedAtRoute("GeEvent", new { id = eventEntityMap.Id }, eventEntityMap);
        }
    }
}