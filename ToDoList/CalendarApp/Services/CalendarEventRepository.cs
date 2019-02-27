using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoList.Data;
using CalendarApp.Entities;

namespace CalendarApp.Services
{
    public class CalendarEventRepository : ICalendarEventRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public CalendarEventRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddEvent(CalendarEvent taskEntity)
        {
            _dbContext.CalendarEvents.Add(taskEntity);
        }

        public void DeleteEvent(CalendarEvent taskEntity)
        {
            _dbContext.Remove(taskEntity);
        }

        public CalendarEvent GetEvent(Guid id)
        {
            return _dbContext.CalendarEvents.FirstOrDefault(t => t.Id == id);
        }

        public CalendarEvent GetEvent(DateTime dateTime)
        {
            return _dbContext.CalendarEvents.FirstOrDefault(te => te.Start == dateTime);
        }

        public IEnumerable<CalendarEvent> GetEvents(DateTime start, DateTime end)
        {
            return _dbContext.CalendarEvents.Where(te => te.Start >= start && te.Start <= end);
        }

        public bool Save()
        {
            return (_dbContext.SaveChanges() >= 0);
        }

        public void UpdateEvent(CalendarEvent taskEntity)
        {
            //uneeded for EF
        }
    }
}
