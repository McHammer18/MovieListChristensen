using Microsoft.AspNetCore.Mvc;
using MovieListChristensen.Models;
using System.Diagnostics;

namespace MovieListChristensen.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult StaticContent(string num)
        {
            return Content($"Static Content: {num}");
        }
        [Route("/")]
        public IActionResult IndexOverride()
        {
            return Content("Index Override!");
        }
        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Display(string id)
        {
            int cnt = Convert.ToInt32(id);
            return View(cnt);
        }
    }
}