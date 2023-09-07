using BusinessLayer.Interface;
using CommonLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MVC.EmployeePayroll.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.EmployeePayroll.Controllers
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
            
            return View();
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
        [HttpGet]
        public IActionResult TempProfile()
        {
            try
            {
                // Retrieve employee data from TempData
                var result = TempData["Employees"] as List<EmployeeModel>;

                if (result != null && result.Count > 0)
                {
                    return View(result);
                }
                else
                {
                    return RedirectToAction("Login");
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions here
                return View("Error");
            }
        }
    }
}
