using CalendarApp.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CalendarApp.Models.Dtos
{
    public class ScheduleCalendarEventDto
    {
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        [DisplayName("Start Date")]
        [Required]
        public string StartDate { get; set; }
        [Required]
        public string StartTime { get; set; }
        [DisplayName("End Date")]
        [Required]
        public string EndDate { get; set; }
        [Required]
        public string EndTime { get; set; }
        [DisplayName("Status")]
        public UserStatus UserStatus { get; set; }
        public bool Cancelled { get; set; }
    }
}
