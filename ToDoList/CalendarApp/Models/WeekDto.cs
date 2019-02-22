using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalendarApp.Models
{
    public class WeekDto
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime LastWeek { get; set; }
        public DateTime NextWeek { get; set; }
    }
}
