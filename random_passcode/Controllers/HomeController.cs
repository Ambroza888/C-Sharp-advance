using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using random_passcode.Models;
using Microsoft.AspNetCore.Http;

namespace random_passcode.Controllers
{
  public class HomeController : Controller
  {
    [HttpGet("")]
    public IActionResult Index()
    {
      HttpContext.Session.SetInt32("passcode", 0);
      int? passcode_int = HttpContext.Session.GetInt32("passcode");
      ViewBag.passcode_int = passcode_int;
      string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
      char[] stringChars = new char[14];
      Random random = new Random();

      for (int i = 0; i < stringChars.Length; i++)
      {
        stringChars[i] = chars[random.Next(chars.Length)];
      }

      string finalString = new string(stringChars);
      ViewBag.fw = finalString;

      return View("Index");
    }
    // -------------------------------------------------------------------------
    // POST
    // -------------------------------------------------------------------------
    [HttpGet("yo")]
    public IActionResult Privacy()
    {
      int? num = HttpContext.Session.GetInt32("passcode");
      HttpContext.Session.SetInt32("passcode", (int)num + 1);
      int? passcode_int = HttpContext.Session.GetInt32("passcode");
      ViewBag.passcode_int = passcode_int;

      string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
      char[] stringChars = new char[14];
      Random random = new Random();

      for (int i = 0; i < stringChars.Length; i++)
      {
        stringChars[i] = chars[random.Next(chars.Length)];
      }

      string finalString = new string(stringChars);
      ViewBag.fw = finalString;
      return View("Index");
    }
























    // -----------------------------------------------------------------------------
    // 
    // -----------------------------------------------------------------------------
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
      return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
  }
}
