using Microsoft.AspNetCore.Mvc;
using MovieListChristensen.Models;

namespace MovieListChristensen.Controllers
{
    public class MovieController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private MovieContext context;

        public MovieController(ILogger<HomeController> logger, MovieContext dbcontext)
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
    }
}
