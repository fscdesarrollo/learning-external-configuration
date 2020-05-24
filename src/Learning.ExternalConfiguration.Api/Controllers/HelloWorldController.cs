using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.FeatureManagement;
using System.Threading.Tasks;

namespace Learning.ExternalConfiguration.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HelloWorldController : ControllerBase
    {
        
        private readonly ILogger<HelloWorldController> _logger;
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IFeatureManager _featureManager;

        public HelloWorldController(ILogger<HelloWorldController> logger, IConfiguration configuration, IWebHostEnvironment webHostEnvironment, IFeatureManager featureManager)
        {
            _logger = logger;
            _configuration = configuration;
            _webHostEnvironment = webHostEnvironment;
            _featureManager = featureManager;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            _logger.LogInformation("Init get to Hellow world");
            var feature = await _featureManager.IsEnabledAsync("NewFeatureFlag");
            if (feature)
            {
                _logger.LogInformation($"Feature NewFeatureFlag value: {feature}");
            }

            string appMessage = _configuration.GetSection("Message:HelloWorld").Value;

            if (_webHostEnvironment.EnvironmentName.Equals("ExternalConfig"))
            {
                return Ok($"{appMessage} extrated from the Repository (Our source)");
            }

            return Ok($"{appMessage} extrated from appsettings.LocalConfig");
        }
            

    }
}
