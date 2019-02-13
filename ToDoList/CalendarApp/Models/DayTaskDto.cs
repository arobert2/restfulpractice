using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoList.Models
{
    public class DayTaskDto
    {
        public DateTime Date { get; set; }
        public List<TaskToDoDto> Days { get; set; }
    }
}
