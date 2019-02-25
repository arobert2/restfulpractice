using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalendarApp.Models
{
    public class EventDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public TimeSpan TimeRequired { get; set; }
        public DateTime Date { get; set; }
    }
}
