using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using form_submission.Models;

namespace form_submission.Controllers
{
    public class HomeController : Controller
    {
        // ---------------------------------------------------------------------
        // Home
        // ---------------------------------------------------------------------
        public IActionResult Index()
        {
            return View("index");
        }
        // ---------------------------------------------------------------------
        // 
        // ---------------------------------------------------------------------
        public IActionResult Privacy()
        {
            return View();
        }
        // ---------------------------------------------------------------------
        // 
        // ---------------------------------------------------------------------










        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
