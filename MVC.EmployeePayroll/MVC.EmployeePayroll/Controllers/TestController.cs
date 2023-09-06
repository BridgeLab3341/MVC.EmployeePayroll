using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace MVC.EmployeePayroll.Controllers
{
    public class TestController : Controller
    {
        //public IActionResult Index()
        //{
        //    return View();
        //}

        public IActionResult Action1()
        {
            List<string> list = new List<string> { "Item1", "Item2", "Item3" };
            TempData["myList"] = list;
            return RedirectToAction("Action2", "Home");
        }

        // 1st Request  
        public ActionResult Index()
        {
            TempData["name"] = "Usama";
            TempData["institute"] = "GCUF";

            return View();
        }

        // 2nd Request  
        public ActionResult Details()
        {
            return View();
        }
    }
}
