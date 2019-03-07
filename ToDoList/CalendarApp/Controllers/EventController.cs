using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CalendarApp.Models;
using CalendarApp.Services;
using AutoMapper;
using CalendarApp.Entities;
using CalendarApp.ExtensionMethods;
using CalendarApp.Models.Dtos;

namespace CalendarApp.Controllers
{
    public class EventController : Controller
    {
        private readonly ICalendarEventRepository _calendarEventRepository;

        public EventController(ICalendarEventRepository calendarEventRepository)
        {
            _calendarEventRepository = calendarEventRepository;
        }

        [HttpGet]
        public IActionResult ScheduleNewEvent()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ScheduleNewEvent(ScheduleCalendarEventDto scheduleCalendarEventDto)
        {
            if (!ModelState.IsValid)
                return View(scheduleCalendarEventDto);

            var mappedCalendarEvent = Mapper.Map<CalendarEvent>(scheduleCalendarEventDto);
            _calendarEventRepository.AddEvent(mappedCalendarEvent);

            if (!_calendarEventRepository.Save())
                return View(scheduleCalendarEventDto);

            return RedirectToAction("Week", "Calendar");
        }
    }
}