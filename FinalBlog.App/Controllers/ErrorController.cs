using Microsoft.AspNetCore.Mvc;

namespace FinalBlog.App.Controllers
{
    public class ErrorController : Controller
    {
        [Route("NotFound")]
        public new IActionResult NotFound() => View();

        [Route("BadRequest")]
        public new IActionResult BadRequest() => View();

        [Route("AccessDenied")]
        public IActionResult AccessDenied() => View();
    }
}
