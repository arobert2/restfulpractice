using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoList.Entities
{
    public class DayEntity
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public DateTime Date { get; set; }
        public ICollection<TaskEntity> Tasks { get; set; }
            = new List<TaskEntity>();
    }
}
