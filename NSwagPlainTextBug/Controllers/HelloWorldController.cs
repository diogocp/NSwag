using Microsoft.AspNetCore.Mvc;

namespace NSwagPlainTextBug.Controllers
{
    [ApiController]
    public class HelloWorldController : ControllerBase
    {
        [HttpGet("hello")]
        public string GetHello()
        {
            return "Hello, World!";
        }
    }
}
