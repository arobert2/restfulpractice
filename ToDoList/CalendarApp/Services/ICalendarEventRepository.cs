using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CalendarApp.Entities;

namespace CalendarApp.Services
{
    public interface ICalendarEventRepository
    {
        void AddEvent(TaskEntity taskEntity);
        TaskEntity GetEvent(Guid id);
        IEnumerable<TaskEntity> GetEvents(DateTime start, DateTime end);
        void DeleteEvent(TaskEntity taskEntity);
        void UpdateEvent(TaskEntity taskEntity);
        bool Save();
    }
}
