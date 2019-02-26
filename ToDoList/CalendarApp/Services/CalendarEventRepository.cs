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

        public void AddEvent(TaskEntity taskEntity)
        {
            _dbContext.TasksToDo.Add(taskEntity);
        }

        public void DeleteEvent(TaskEntity taskEntity)
        {
            _dbContext.Remove(taskEntity);
        }

        public TaskEntity GetEvent(Guid id)
        {
            return _dbContext.TasksToDo.FirstOrDefault(t => t.Id == id);
        }

        public TaskEntity GetEvent(DateTime dateTime)
        {
            return _dbContext.TasksToDo.FirstOrDefault(te => te.Start == dateTime);
        }

        public IEnumerable<TaskEntity> GetEvents(DateTime start, DateTime end)
        {
            return _dbContext.TasksToDo.Where(te => te.Start >= start && te.Start <= end);
        }

        public bool Save()
        {
            return (_dbContext.SaveChanges() >= 0);
        }

        public void UpdateEvent(TaskEntity taskEntity)
        {
            //uneeded for EF
        }
    }
}
