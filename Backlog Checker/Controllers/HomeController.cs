using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Backlog_Checker.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Session;

namespace Backlog_Checker.Controllers
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
            HttpContext.Session.SetInt32("userId", 2);
            HttpContext.Session.SetString("username", "Pandango");

            if (CheckIfUserIsLoggedIn())
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
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

        private bool CheckIfUserIsLoggedIn()
        {
            if(HttpContext.Session.GetInt32("userId") != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
