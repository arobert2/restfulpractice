using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CalendarApp.Entities
{
    public class TaskEntity
    {
        [Key]
        public Guid Id { get; set; }
        [MaxLength(20)]
        [Required]
        public string Title { get; set; }
        [MaxLength(100)]
        public string Description { get; set; }
        [Required]
        public TimeSpan TimeRequired { get; set; }
        [Required]
        public DateTime Date { get; set; }
        public bool Completed { get; set; } = false;
    }
}
