using Microsoft.AspNetCore.Mvc;
using MovieListChristensen.Models;
using System.Diagnostics;

namespace MovieListChristensen.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminHomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
