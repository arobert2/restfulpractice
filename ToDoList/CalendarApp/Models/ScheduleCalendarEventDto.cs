using CalendarApp.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace CalendarApp.Models
{
    public class ScheduleCalendarEventDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        [DisplayName("Start Date")]
        public string StartDate { get; set; }
        public string StartTime { get; set; }
        [DisplayName("End Date")]
        public string EndDate { get; set; }
        public string EndTime { get; set; }
        [DisplayName("Status")]
        public UserStatus UserStatus { get; set; }
        public bool Cancelled { get; set; }
    }
}
