using Microsoft.AspNetCore.Mvc;
using MovieListChristensen.Models;
using System.Diagnostics;

namespace MovieListChristensen.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminHomeController : Controller
    {
            private readonly ILogger<AdminHomeController> _logger;

            public AdminHomeController(ILogger<AdminHomeController> logger)
            {
                _logger = logger;
            }

            public IActionResult Index()
            {
                return View();
            }

            public IActionResult Privacy()
            {
                return View();
            }

            [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        }
    }
