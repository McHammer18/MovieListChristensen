using Microsoft.AspNetCore.Mvc;

namespace MovieListChristensen.Controllers
{
    [Route("Custom/[controller]/[action]")]
    public class OtherController : Controller
    {
        public IActionResult Index()
        {
            return Content("Other Controller!");
        }
    }
}
