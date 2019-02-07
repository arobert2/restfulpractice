using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Services;

namespace ToDoList.Controllers
{
    [Route("api/Day")]
    public class DayTaskController : Controller
    {
        private readonly IToDoRepository _toDoRepository;
    }
}