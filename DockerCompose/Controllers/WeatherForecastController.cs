using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DockerCompose.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DockerCompose.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        
        private readonly ComposeContext _context;

        public WeatherForecastController(ComposeContext context)
        {
            _context = context;   
        }

        [HttpGet]
        public ActionResult<IEnumerable<User>> GetUsers(){
            return _context.Users;
        }

    }
}
