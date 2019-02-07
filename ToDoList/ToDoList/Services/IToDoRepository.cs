using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoList.Entities;

namespace ToDoList.Services
{
    public interface IToDoRepository
    {
        void AddDay(DayTask day);
        DayTask GetDay(DateTime date);
        DayTask GetDay(Guid id);
        ICollection<DayTask> GetDays(DateTime start, DateTime end);
        void DeleteDay(DayTask day);
        bool DayExists(Guid id);
        void AddTask(TaskToDo task);
        void UpdateTask(TaskToDo task);
        TaskToDo GetTask(Guid id);
        ICollection<TaskToDo> GetTasks(DayTask day);
        bool Save();
    }
}
