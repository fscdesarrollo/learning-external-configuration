using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Learning.ExternalConfiguration.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HelloWorldController : ControllerBase
    {
        
        private readonly ILogger<HelloWorldController> _logger;
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public HelloWorldController(ILogger<HelloWorldController> logger, IConfiguration configuration, IWebHostEnvironment webHostEnvironment)
        {
            _logger = logger;
            _configuration = configuration;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet]
        public IActionResult Get()
        {
            _logger.LogInformation("Init get to Hellow world");

            string appMessage = _configuration.GetSection("Message:HelloWorld").Value;

            if (_webHostEnvironment.EnvironmentName.Equals("ExternalConfig"))
            {
                return Ok($"{appMessage} extrated from the Repository (Our source)");
            }

            return Ok($"{appMessage} extrated from appsettings.LocalConfig");
        }
            

    }
}
