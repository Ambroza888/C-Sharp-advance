using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using dojoachi.Models;
using Microsoft.AspNetCore.Http;

namespace dojoachi.Controllers
{
    // -------------------------------------------------------------------------
    // Class Dachi
    // -------------------------------------------------------------------------
    class Dachi 
    {
        // static Random rand = new Random();
        public int Happiness {get;set;}
        public int Fullness {get;set;}
        public int Energy {get;set;}
        public int Meals {get;set;}
        public string Message {get;set;}
        public Dachi()
        {
            Happiness = 20;
            Fullness = 20;
            Energy = 50;
            Meals = 3;
            Message = "hi";
        }
    }
        // public void Feed()
        // {
        //     if( Meals > 0)
        //     {
        //         if (rand.Next(1,5) == 1){
        //             Meals -=1;
        //             Message = $"Sorry the Gochi didn't like the meal.";
        //             }
        //         else{
        //             Meals -=1;
        //             int num = rand.Next(5,11);
        //             Fullness +=  num;
        //             Message = $"You gocci loved the Meal and gained {num} to his Fullness";
        //             }
        //     }
        //     else{Message = "Sorry you don't have Enought Meals";}
        // }
        // public void Play()
        // {
        //     if (Energy > 4)
        //     {
        //         if (rand.Next(1,5) == 1)
        //         {
        //             Energy -= 5;
        //             Message = $"Sorry the gocci didn't like this play";
        //         }
        //         else
        //         {
        //             Energy -=5;
        //             int num = rand.Next(5,11);
        //             Happiness += num;
        //             Message = $"Gocchi lost 5 Energy but gained {num} Happiness";
        //         }
        //     }
        //     else{ Message = "Sorry you don't have Enought Energy";}
        // }
        // public void Work()
        // {
        //     Energy -= 5;
        //     int num = rand.Next(1,4);
        //     Meals += num;
        //     Message = $"You lost 5 energy but you Gained {num} meals";
        // }
        // public void Sleep()
        // {
        //     Energy += 15;
        //     Fullness -= 5;
        //     Happiness -= 5;
        // }

    // }
    // -------------------------------------------------------------------------
    // HomeController
    // -------------------------------------------------------------------------
    public class HomeController : Controller
    {
        Dachi Stas = new Dachi();
        Random rand = new Random();
        public IActionResult Index()
        {
            if (HttpContext.Session.GetInt32("Energy")== null)
            {
            HttpContext.Session.SetInt32("Happpiness",Stas.Happiness);
            HttpContext.Session.SetInt32("Fullness",Stas.Fullness);
            HttpContext.Session.SetInt32("Energy",Stas.Energy);
            HttpContext.Session.SetInt32("Meals",Stas.Meals);
            HttpContext.Session.SetString("Message",Stas.Message);
            }
            ViewBag.Happiness =  HttpContext.Session.GetInt32("Happpiness");
            ViewBag.Fullness = HttpContext.Session.GetInt32("Fullness");
            ViewBag.Energy = HttpContext.Session.GetInt32("Energy");
            ViewBag.Meals = HttpContext.Session.GetInt32("Meals");
            ViewBag.Message = HttpContext.Session.GetString("Message");
            if (ViewBag.Fullness < 1 || ViewBag.Happiness < 1)
            {
                ViewBag.Message = "Your Dachi just died ....";
                ViewBag.died = "dead";
            }
            if (ViewBag.Happiness > 99 && ViewBag.Energy > 99 && ViewBag.Fullness > 99)
            {
                ViewBag.Message = "You HAVE JUST WON !....";
                ViewBag.Won = "won";
            }
            return View();
        }
        [HttpGet("Feed")]
        public IActionResult Feed()
        {
            if(HttpContext.Session.GetInt32("Meals") > 0)
            {
                if (rand.Next(1,5) == 1){
                    // taking from session and decrem and adding back to it;
                    int? temp = HttpContext.Session.GetInt32("Meals");
                    temp--;
                    HttpContext.Session.SetInt32("Meals",(int)temp);
                    // taking the mess and updating it
                    string stringtemp= $"Sorry the Gochi didn't like the meal.";
                    HttpContext.Session.SetString("Message",stringtemp);
                    }
                else{
                    // taking from session and decrem and adding back to it;
                    int? mealtemp = HttpContext.Session.GetInt32("Meals");
                    mealtemp--;
                    HttpContext.Session.SetInt32("Meals",(int)mealtemp);

                    //adding fullness
                    int num = rand.Next(5,11);
                    int? fultemp = HttpContext.Session.GetInt32("Fullness");
                    HttpContext.Session.SetInt32("Fullness",(int)fultemp + num);
                    //adding message;
                    string mess = $"Your gocci loved the Meal and gained {num} to his Fullness";
                    HttpContext.Session.SetString("Message",mess);
                    }
            }
            else{
                string mess = "Sorry you don't have Enought Meals";
                HttpContext.Session.SetString("Message",mess);
                }
            // int? yo = HttpContext.Session.GetInt32("Energy");
            // yo = yo+1;
            // HttpContext.Session.SetInt32("Energy", (int)yo);

            return RedirectToAction("Index");
        }
        // ---------------------------------------------------------------------
        // Work
        // ---------------------------------------------------------------------
    [HttpGet("Work")]
    public IActionResult Work()
    {
        if (HttpContext.Session.GetInt32("Energy") > 4){
        //---------- take energy------------
        int? tEnergy = HttpContext.Session.GetInt32("Energy");
        tEnergy -= 5;
        HttpContext.Session.SetInt32("Energy",(int)tEnergy);
        // ----------add Meals-----------------------------
        int numMeal = rand.Next(1,4);
        int? tmeals = HttpContext.Session.GetInt32("Meals");
        tmeals += numMeal;
        HttpContext.Session.SetInt32("Meals",(int)tmeals);
        }
        else
        {
            string tstring = $"You don't have enougt energy to Work";
            HttpContext.Session.SetString("Message",tstring);
        }
        return RedirectToAction("Index");
    }
    [HttpGet("Sleep")]
    public IActionResult Sleep()
    {
        if (HttpContext.Session.GetInt32("Happiness") > 0 || HttpContext.Session.GetInt32("Fullness") > 0)
        {
        // Energy
        int? tenergy = HttpContext.Session.GetInt32("Energy");
        HttpContext.Session.SetInt32("Energy",((int)tenergy)+15);
        // Fullness
        int? tfullness = HttpContext.Session.GetInt32("Fullness");
        HttpContext.Session.SetInt32("Fullness",(int)tfullness -5);
        //Happiness
        int? thappiness = HttpContext.Session.GetInt32("Happpiness");
        HttpContext.Session.SetInt32("Happpiness",(int)thappiness -5);
        }
        else
        {
            string tstring = "You don't have enought Energy or Fullness";
            HttpContext.Session.SetString("Message",tstring);
        }
        return RedirectToAction("Index");
    }
    [HttpGet("Play")]
    public IActionResult Play()
    {
        if (HttpContext.Session.GetInt32("Energy") > 4){
            if (rand.Next(1,5) == 1)
            {
                int? tenergy = HttpContext.Session.GetInt32("Energy");
                HttpContext.Session.SetInt32("Energy",(int)tenergy -5);
                string tmessage = "Sorry the gochi didn't like that game. You lost 5 Energy";
                HttpContext.Session.SetString("Message",tmessage);
            }
            else
            {
                int? tenergy = HttpContext.Session.GetInt32("Energy");
                HttpContext.Session.SetInt32("Energy",(int)tenergy -5);
                // gain happiness
                int? thappy = HttpContext.Session.GetInt32("Happpiness");
                int trand = rand.Next(5,11);
                HttpContext.Session.SetInt32("Happpiness",(int)thappy+trand);
                //Message
                string tmessage = $"You have lost 5 Energy but gained {trand} Happpiness";
                HttpContext.Session.SetString("Message",tmessage);
            }
        }
        //if (Energy > 4)
        //     {
        //         if (rand.Next(1,5) == 1)
        //         {
        //             Energy -= 5;
        //             Message = $"Sorry the gocci didn't like this play";
        //         }
        //         else
        //         {
        //             Energy -=5;
        //             int num = rand.Next(5,11);
        //             Happiness += num;
        //             Message = $"Gocchi lost 5 Energy but gained {num} Happiness";
        //         }
        //     }
        //     else{ Message = "Sorry you don't have Enought Energy";}
        return RedirectToAction("Index");
    }
    [HttpGet("Restart")]
    public IActionResult Restart()
    {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
    }















// -----------------------------------------------------------------------------
// Error
// -----------------------------------------------------------------------------

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }

}
