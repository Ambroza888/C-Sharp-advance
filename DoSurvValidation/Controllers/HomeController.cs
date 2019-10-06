using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DoSurvValidation.Models;

namespace DoSurvValidation.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("")]
        public IActionResult Index()
        {
            return View("Index");
        }

        [HttpPost("result")]
        public IActionResult Result(Survey yo)
        {
            if(ModelState.IsValid)
                return View("result", yo);
            return View("Index");
        }




















        
        // ---------------------------------------------------------------------
        // Cache
        // ---------------------------------------------------------------------

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
