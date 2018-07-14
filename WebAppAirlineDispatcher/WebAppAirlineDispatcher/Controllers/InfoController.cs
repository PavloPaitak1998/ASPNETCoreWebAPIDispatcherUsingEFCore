using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebAppAirlineDispatcher.Controllers
{
    [Route("api/[controller]")]
    public class InfoController : Controller
    {
        // GET: api/info
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new {Information= "This is ASP .NET Core Web API App representing the work of the Airline Dispatcher" });
        }
    }
}