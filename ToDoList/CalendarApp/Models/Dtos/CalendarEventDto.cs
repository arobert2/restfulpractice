using CalendarApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalendarApp.Models.Dtos
{
    
    public class CalendarEventDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public UserStatus UserStatus { get; set; }
        public bool Cancelled { get; set; }
    }
}
