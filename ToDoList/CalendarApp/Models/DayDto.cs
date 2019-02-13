using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoList.Models
{
    public class DayDto
    {
        public DateTime Date { get; set; }

        public DayOfWeek DayOfWeek => Date.DayOfWeek;
        public List<TaskDto> Tasks { get; set; }
    }
}
