using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalendarApp.Models.ViewModels
{
    public class CalendarToolBarViewModel
    {
        public DateTime CurrentDate { get; set; }
        public DateTime LastDate { get; set; }
        public DateTime NextDate { get; set; }
        public string ToolbarText { get; set; }
        public string ViewActionName { get; set; }
    }
}
