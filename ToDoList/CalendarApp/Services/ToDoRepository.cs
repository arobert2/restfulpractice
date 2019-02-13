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

        public void AddDay(DayEntity day)
        {
            _context.DayTasks.Add(day);
        }

        public void AddTask(TaskEntity task)
        {
            _context.TasksToDo.Add(task);
        }

        public bool DayExists(Guid id)
        {
            return _context.DayTasks.FirstOrDefault(dt => dt.Id == id) != null;
        }

        public void DeleteDay(DayEntity day)
        {
            _context.DayTasks.Remove(day);
        }

        public DayEntity GetDay(DateTime date)
        {
            return _context.DayTasks.FirstOrDefault(dt => dt.Date == date);
        }

        public DayEntity GetDay(Guid id)
        {
            return _context.DayTasks.FirstOrDefault(dt => dt.Id == id);
        }

        public ICollection<DayEntity> GetDays(DateTime start, DateTime end)
        {
            return _context.DayTasks.Where(dt => dt.Date >= start && dt.Date <= end).ToList();
        }

        public TaskEntity GetTask(Guid id)
        {
            return _context.TasksToDo.FirstOrDefault(ttd => ttd.Id == id);
        }

        public ICollection<TaskEntity> GetTasks(DayEntity day)
        {
            return _context.TasksToDo.Where(ttd => ttd.DayId == day.Id).ToList();
        }

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateTask(TaskEntity task)
        {
            //Implemintation unneeded.
        }
    }
}
