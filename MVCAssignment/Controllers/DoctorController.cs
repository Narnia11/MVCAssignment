using Microsoft.AspNetCore.Mvc;
using MVCAssignment.Model;
using MVCAssignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCAssignment.Controllers
{

    public class DoctorController : Controller
    {


        public DoctorController()
        {

        }

        public ActionResult CheckFever(string result = "")
        {
            if (!string.IsNullOrEmpty(result))
            {
                ViewData["fever"] = result;
            }



            return View();
        }
        [HttpPost]
        public ActionResult CheckFever(Fever model)
        {

            return RedirectToAction(nameof(CheckFever), new { result = Utility.CheckFever(model) });

        }
    }
}