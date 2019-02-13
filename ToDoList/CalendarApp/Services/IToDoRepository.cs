using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoList.Entities;

namespace ToDoList.Services
{
    public interface IToDoRepository
    {
        void AddDay(DayEntity day);
        DayEntity GetDay(DateTime date);
        DayEntity GetDay(Guid id);
        ICollection<DayEntity> GetDays(DateTime start, DateTime end);
        void DeleteDay(DayEntity day);
        bool DayExists(Guid id);
        void AddTask(TaskEntity task);
        void UpdateTask(TaskEntity task);
        TaskEntity GetTask(Guid id);
        ICollection<TaskEntity> GetTasks(DayEntity day);
        bool Save();
    }
}
