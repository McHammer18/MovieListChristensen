using Microsoft.AspNetCore.Mvc;
using MovieListChristensen.Models;
using System.Diagnostics;

namespace MovieListChristensen.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private MovieContext context;

        public HomeController(ILogger<HomeController> logger, MovieContext dbcontext)
        {
            _logger = logger;
            context = dbcontext;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var movies = context.Movies
                .OrderBy(m => m.Name)
                .ToList();
            return View(movies);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}