using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CalendarApp.Models;
using CalendarApp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CalendarApp.Controllers
{
    [Route("api/events")]
    [ApiController]
    public class EventCollectionsApiController : Controller
    {
        private readonly ICalendarEventRepository _calendarRepository;

        public EventCollectionsApiController(ICalendarEventRepository calendarEventRepository)
        {
            _calendarRepository = calendarEventRepository;
        }
        /// <summary>
        /// Get events for that particular day
        /// </summary>
        /// <param name="datetime">DateTime object of day</param>
        /// <returns>Event data</returns>
        [HttpGet("/day/{datetime}")]
        public IActionResult GetDayEvents(DateTime datetime)
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
    }
}