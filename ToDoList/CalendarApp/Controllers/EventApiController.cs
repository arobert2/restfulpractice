using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CalendarApp.Models;
using CalendarApp.Services;
using Microsoft.AspNetCore.Mvc;
using CalendarApp.Entities;
using AutoMapper;
using CalendarApp.Models.Dtos;

namespace CalendarApp.Controllers
{
    [Route("api/event")]
    [ApiController]
    public class EventApiController : Controller
    {
        private readonly ICalendarEventRepository _calendarRepository;
        public EventApiController(ICalendarEventRepository calendarRepository)
        {
            _calendarRepository = calendarRepository;
        }
        [HttpGet("{id}", Name = "GetEvent")]
        public IActionResult GetEvent(Guid id)
        {
            var eventFromRepo = _calendarRepository.GetEvent(id);
            if (eventFromRepo == null)
                return NotFound();
            var eventFromMap = Mapper.Map<CalendarEventDto>(eventFromRepo);
            return Ok(eventFromRepo);
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
        public IActionResult ScheduleEvent([FromBody]ScheduleCalendarEventDto scheduleCalendarEventDto)
        {
            if (scheduleCalendarEventDto == null)
                return BadRequest();

            var eventEntityMap = Mapper.Map<CalendarEvent>(scheduleCalendarEventDto);

            _calendarRepository.AddEvent(eventEntityMap);
            if (!_calendarRepository.Save())
                throw new Exception("Failed to create event on save.");
            return CreatedAtRoute(routeName: "GetEvent", routeValues: new { id = eventEntityMap.Id }, value: eventEntityMap);
        }
        [HttpPatch("{id}")]
        public IActionResult UpdateEvent(Guid id, [FromBody] UpdateCalendarEventDto updateCalendarEventDto)
        {
            return Ok();
        }
    }
}