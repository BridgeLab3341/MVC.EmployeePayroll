using BusinessLayer.Interface;
using CommonLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MVC.EmployeePayroll.Controllers
{
    public class EmpController : Controller
    {
        private readonly IEmpBusiness empBusiness;
        public  EmpController(IEmpBusiness empBusiness)
        {
            this.empBusiness = empBusiness;
        }
        public IActionResult Index()
        {
            try
            {
                //List<EmployeeModel> models = new List<EmployeeModel>();
                var models = empBusiness.GetAllEmployees();
                 return View(models);
                
            }
            catch (Exception)
            {
                throw new Exception("Exception Occured while Fetching Index View");
            }
        }
        [HttpGet]
        [Route("Emp/AddEmp")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Route("Emp/AddEmp")]
        [ValidateAntiForgeryToken]
        public IActionResult Create(EmployeeModel employee)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    empBusiness.Create(employee);
                    return RedirectToAction("Index");
                }
                return View(employee);
            }
            catch (Exception)
            {
                throw new Exception("Exception Occured while Adding Employee Data");
            }
        }
        //[HttpGet]
        //public IActionResult GetAllEmployees()
        //{
        //    try
        //    {
        //        List<EmployeeModel> models = new List<EmployeeModel>();
        //        var result = empBusiness.GetAllEmployees();
        //        return View(result);
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}
        [HttpGet]
        [Route("Emp/Update")]
        public IActionResult Edit(int employeeid)
        {
            try
            {
                if (employeeid == null)
                {
                    return NotFound();
                }
                var result = empBusiness.GetAllEmployees();
                var employee = result.FirstOrDefault(x => x.EmployeeId == employeeid);
                //var employee = empBusiness.GetEmployeeData(employeeid);

                if (employee == null)
                {
                    return NotFound();
                }
                return View(employee);
            }
            catch (Exception)
            {
                throw new Exception("Exception Occured while Updating Employee Data");
            }
        }
        [HttpPost]
        [Route("Emp/Update")]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int employeeId, EmployeeModel employee)
        {
            try
            {
                if (employeeId != employee.EmployeeId)
                {
                    return NotFound();
                }
                if (ModelState.IsValid)
                {
                    empBusiness.Update(employee);
                    return RedirectToAction("Index");
                }
                return View(employee);
            }
            catch (Exception)
            {
                throw new Exception("Exception Occured while Updating Employee Data");
            }
        }
        [HttpGet]
        [Route("Emp/Remove")]
        public IActionResult Delete(int? employeeId)
        {
            try
            {
                if (employeeId == null)
                {
                    return NotFound();
                }
                //var result = empBusiness.GetAllEmployees();

                //var employee = result.FirstOrDefault(x => x.EmployeeId == employeeId);

                EmployeeModel employee = empBusiness.GetEmployeeData(employeeId);
                ViewBag.Message = "Data Deleted Successfully".ToString();
                if (employee == null)
                {
                    return NotFound();
                }
                return View(employee);
            }
            catch (Exception)
            {
                throw new Exception("Exception Occured while Deleting Employee Data");
            }
        }
        [HttpPost,ActionName("Delete")]
        [Route("Emp/Remove")]
        public IActionResult DeleteConfirm(int? employeeId)
        {
            try
            {              
                empBusiness.DeleteEmployee(employeeId);
                ViewBag.Message = "Data Deleted Successfully".ToString();
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                throw new Exception("Exception Occured while Deleting Employee Data");
            }
        }
        [HttpGet]
        [Route("Emp/UserData")]
        public IActionResult Details(int employeeId)
        {
            if(employeeId == null)
            {
                return NotFound();
            }
            //var result= empBusiness.GetAllEmployees();
            //var employee = result.FirstOrDefault(x=>x.EmployeeId == employeeId);
            var employee= empBusiness.GetEmployeeData(employeeId);
            ViewBag.Message = "Data Fetched Successfully".ToString();
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }
        [HttpGet]
        [Route("Emp/Login")]
        public IActionResult Login()
        {
            try
            {
                // HttpContext.Session.Clear();
                
                return View();                
            }
            catch (Exception)
            {
                throw new Exception("Exception Occured while Login");
            }
        }
        [HttpPost]
        public IActionResult Login(EmployeeLoginModel login)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    var result = this.empBusiness.GetAllEmployees();
                    var employee = result.FirstOrDefault(x => x.EmployeeId == login.EmployeeId);
                    HttpContext.Session.SetInt32("EmployeeId", employee.EmployeeId);
                    if (employee != null)
                    {
                        
                        return RedirectToAction("Profile");
                    }
                    else
                    { 
                        return RedirectToAction("Login");
                    }
                }
                return View(login);
            }
            catch (Exception)
            {
                throw new Exception("Exception Occured while Login");
            }
        }

        [HttpGet]
        [Route("Emp/Profile")]
        public IActionResult Profile()
        {
            try 
            { 
                int EmpId = (int)HttpContext.Session.GetInt32("EmployeeId");
                var result = this.empBusiness.GetAllEmployees();
                var employee = result.FirstOrDefault(x => x.EmployeeId == EmpId);
                ViewBag.Message = "Login Successfully".ToString();
                if (employee != null)
                {
                    return View(employee);
                }
                else
                {
                    return RedirectToAction("Login");
                }

            }
            catch (Exception)
            {
                throw new Exception("Exception Occured while Login");
            }
        }
        [HttpGet]
        [Route("Emp/Temp")]
        public IActionResult Temperary()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                // Handle exceptions here
                return View("Error");
            }
        }
        [HttpPost]
        [Route("Emp/Temp")]
        public IActionResult TemperaryData()
        {
            try
            {
                var result = empBusiness.GetAllEmployees();

                // Store employee data in TempData
                TempData["Employees"] = result;

                if (result != null)
                {
                    return RedirectToAction("TempProfile", "Home");
                }
                else
                {
                    return RedirectToAction("Login", "Home");
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