using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVCAssignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCAssignment.Controllers
{
    public class GameController : Controller
    {
        public ActionResult Index(string result = "", int counter = 0)
        {
            // A random number within a range  
            if (HttpContext.Session.GetString("RandomNumber") == null)
            {
                Random random = new Random();
                int randomNumber = random.Next(1, 100);
                HttpContext.Session.SetString("RandomNumber", randomNumber.ToString());
            }
            if (!string.IsNullOrEmpty(result))
            {
                ViewData["resultMessage"] = result;
            }
            if (counter > 0)
            {
                ViewData["counter"] = counter;

            }

            return View();
        }



        [HttpPost]
        public ActionResult GuessNumber(int GussingNumber)
        {
            Utility.Counter += 1;
            // var x = Convert.ToInt32(HttpContext.Session.GetString("RandomNumber"));
            string resultMessage;
            if (GussingNumber == Convert.ToInt32(HttpContext.Session.GetString("RandomNumber")))
            {
                resultMessage = "It's correct!";
            }
            else if (GussingNumber > Convert.ToInt32(HttpContext.Session.GetString("RandomNumber")))
            {
                resultMessage = "It's greater than the number";
            }
            else
            {
                resultMessage = "It's lower than the number";
            }

            return RedirectToAction(nameof(Index), new { result = resultMessage, counter = Utility.Counter });


        }

        public ActionResult ResetGame()
        {
            Utility.Counter = 0;
            if (HttpContext.Session.GetString("RandomNumber") != null)
            {
                HttpContext.Session.Remove("RandomNumber");

            }

            return RedirectToAction(nameof(Index));


        }

    }
}

