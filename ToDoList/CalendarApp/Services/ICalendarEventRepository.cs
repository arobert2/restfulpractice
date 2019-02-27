using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CalendarApp.Entities;

namespace CalendarApp.Services
{
    public interface ICalendarEventRepository
    {
        void AddEvent(CalendarEvent taskEntity);
        CalendarEvent GetEvent(Guid id);
        CalendarEvent GetEvent(DateTime dateTime);
        IEnumerable<CalendarEvent> GetEvents(DateTime start, DateTime end);
        void DeleteEvent(CalendarEvent taskEntity);
        void UpdateEvent(CalendarEvent taskEntity);
        bool Save();
    }
}
