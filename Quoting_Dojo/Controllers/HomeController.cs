using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Quoting_Dojo.Models;
using DbConnection;

namespace Quoting_Dojo.Controllers
{
  public class HomeController : Controller
  {
    // -------------------------------------------------------------------------
    // Index
    // -------------------------------------------------------------------------
    [HttpGet("")]
    public IActionResult Index()
    {
        
        return View("Index");
    }
// -----------------------------------------------------------------------------
// SHOWING
// -----------------------------------------------------------------------------
    [HttpGet("Show")]
    public IActionResult ilustrate()
    {
        List<Dictionary<string, object>> all = DbConnector.Query("SELECT * FROM quote");
        ViewBag.all = all;
        return View("Show");
    }
// -----------------------------------------------------------------------------
// POSTING
// -----------------------------------------------------------------------------
    [HttpPost("Create")]
    public IActionResult Create(Name _name)
    {
        string query = $"INSERT INTO quote (name,quote,created_at,updated_at) VALUES ('{_name.name}','{_name.quote}',NOW(),NOW())";
        System.Console.WriteLine(query);
        DbConnector.Execute(query);
        
        return RedirectToAction("ilustrate");
    }






















// -----------------------------------------------------------------------------
// ERRORRRRRR
// -----------------------------------------------------------------------------

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
      return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
  }
}
