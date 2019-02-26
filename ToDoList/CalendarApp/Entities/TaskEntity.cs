using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CalendarApp.Entities
{
    public enum UserStatus { Busy, Free, OutOfOffice, InMeeting }
    public class TaskEntity
    {
        [Key]
        public Guid Id { get; set; }
        [MaxLength(20)]
        [Required]
        public string Title { get; set; }
        [MaxLength(100)]
        public string Description { get; set; }
        [MaxLength(50)]
        public string Location { get; set; }
        [Required]
        public DateTime Start { get; set; }
        [Required]
        public DateTime End { get; set; }
        [Required]
        public UserStatus UserStatus { get; set; }
        public bool Cancelled { get; set; } = false;
    }
}
