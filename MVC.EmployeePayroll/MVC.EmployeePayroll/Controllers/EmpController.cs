using BusinessLayer.Interface;
using CommonLayer;
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
            //List<EmployeeModel> models = new List<EmployeeModel>();
            var models = empBusiness.GetAllEmployees();
            return View(models);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind] EmployeeModel employee)
        {
            if (ModelState.IsValid)
            {
                empBusiness.Create(employee);
                return RedirectToAction("Index");
            }
            return View(employee);
        }
        [HttpGet]
        public IActionResult GetAllEmployees()
        {
            try
            {
                List<EmployeeModel> models = new List<EmployeeModel>();
                var result = empBusiness.GetAllEmployees();
                return View(result);
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpGet]
        public IActionResult Edit(int employeeid)
        {
            if (employeeid == null)
            {
                return NotFound();
            }
            var employee = empBusiness.GetEmployeeData(employeeid);

            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int employeeId, [Bind] EmployeeModel employee)
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
        [HttpGet]
        public IActionResult Delete(int? employeeid)
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
        [HttpGet]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirm(int employeeid)
        {
            try
            {
                empBusiness.DeleteEmployee(employeeid);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
