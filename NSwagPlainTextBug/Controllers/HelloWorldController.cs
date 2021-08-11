using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace NSwagPlainTextBug.Controllers
{
    [ApiController]
    public class HelloWorldController : ControllerBase
    {
        private readonly ILogger<HelloWorldController> _logger;

        public HelloWorldController(ILogger<HelloWorldController> logger)
        {
            _logger = logger;
        }

        [HttpGet("hello")]
        public string GetHello()
        {
            Request.Headers.TryGetValue("Accept", out var accept);
            _logger.LogInformation("Request with Accept: {accept}", accept);

            return "Hello, World!";
        }
    }
}
