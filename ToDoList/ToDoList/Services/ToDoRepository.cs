using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoList.Data;
using ToDoList.Entities;

namespace ToDoList.Services
{
    public class ToDoRepository : IToDoRepository
    {
        private readonly ApplicationDbContext _context;

        public ToDoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddDay(DayTask day)
        {
            _context.DayTasks.Add(day);
        }

        public void AddTask(TaskToDo task)
        {
            _context.TasksToDo.Add(task);
        }

        public bool DayExists(Guid id)
        {
            return _context.DayTasks.FirstOrDefault(dt => dt.Id == id) != null;
        }

        public void DeleteDay(DayTask day)
        {
            _context.DayTasks.Remove(day);
        }

        public DayTask GetDay(DateTime date)
        {
            return _context.DayTasks.FirstOrDefault(dt => dt.Date == date);
        }

        public DayTask GetDay(Guid id)
        {
            return _context.DayTasks.FirstOrDefault(dt => dt.Id == id);
        }

        public ICollection<DayTask> GetDays(DateTime start, DateTime end)
        {
            return _context.DayTasks.Where(dt => dt.Date >= start && dt.Date <= end).ToList();
        }

        public TaskToDo GetTask(Guid id)
        {
            return _context.TasksToDo.FirstOrDefault(ttd => ttd.Id == id);
        }

        public ICollection<TaskToDo> GetTasks(DayTask day)
        {
            return _context.TasksToDo.Where(ttd => ttd.Day == day.Id).ToList();
        }

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateTask(TaskToDo task)
        {
            //Implemintation unneeded.
        }
    }
}
