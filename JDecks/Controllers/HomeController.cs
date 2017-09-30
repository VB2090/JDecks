using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using JDecks.Models;

namespace JDecks.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Message"] = "Welcome to JDecks!";

            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Who we are and what we do";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Tell us what you think!";

            return View();
        }

        public IActionResult Resources()
        {
            ViewData["Message"] = "Looking for something extra?";

            return View();
        }

        public IActionResult Practice()
        {
            ViewData["Message"] = "Let's get started!";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
