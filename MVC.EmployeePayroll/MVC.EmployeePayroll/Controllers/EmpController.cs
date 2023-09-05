﻿using BusinessLayer.Interface;
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
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpGet]
        [Route("Emp/AddEmp")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
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
            catch (Exception ex)
            {
                throw ex;
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
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPost]
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
            catch (Exception ex)
            {
                throw ex;
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

                if (employee == null)
                {
                    return NotFound();
                }
                return View(employee);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        [HttpPost,ActionName("Delete")]
        public IActionResult DeleteConfirm(int? employeeId)
        {
            try
            {              
                empBusiness.DeleteEmployee(employeeId);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                throw ex;
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
                HttpContext.Session.Clear();
                    return View();
                
            }
            catch(Exception ex)
            {
                throw ex;
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
            catch (Exception ex)
            {
                throw ex;
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

                if (employee != null)
                {
                    return View(employee);
                }
                else
                {
                    return RedirectToAction("Login");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}