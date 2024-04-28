using LoggerService;
using Microsoft.AspNetCore.Mvc;

namespace CompanyEmployees.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILoggerManager _loggerManager;

        public WeatherForecastController(ILoggerManager loggerManager)
        {
            _loggerManager = loggerManager;
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {
            _loggerManager.LogInfo("Here is info message from our values controller."); 
            _loggerManager.LogDebug("Here is debug message from our values controller."); 
            _loggerManager.LogWarning("Here is warn message from our values controller.");
            _loggerManager.LogError("Here is an error message from our values controller."); 
            
            return new string[] { "value1", "value2" };
        }
    }
}
