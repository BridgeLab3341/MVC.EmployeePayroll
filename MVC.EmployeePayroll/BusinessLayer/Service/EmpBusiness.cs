using BusinessLayer.Interface;
using CommonLayer;
using RepoLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Service
{
    public class EmpBusiness : IEmpBusiness
    {
        private readonly IEmpRepo empRepo;
        public EmpBusiness(IEmpRepo empRepo)
        {
            this.empRepo = empRepo;
        }
        public string Create(EmployeeModel employee)
        {
            try
            {
               return this.empRepo.Create(employee);
            }
            catch (Exception)
            {
                throw new Exception("Exception Occured while Adding Employee Data");
            }
        }
        public IEnumerable<EmployeeModel> GetAllEmployees()
        {
            try
            {
               return this.empRepo.GetAllEmployees();
            }
            catch (Exception)
            {
                throw new Exception("Exception Occured while Fetching All Employee Data");
            }
        }
        public EmployeeModel Update(EmployeeModel employee)
        {
            try
            {
                return this.empRepo.Update(employee);
            }
            catch (Exception)
            {
                throw new Exception("Exception Occured while Updating Employee Data");
            }
        }
        public EmployeeModel GetEmployeeData(int? employeeId)
        {
            try
            {
                return this.empRepo.GetEmployeeData(employeeId);
            }
            catch (Exception)
            {
                throw new Exception("Exception Occured while Fetching Employee Data by EmployeeId");
            }
        }
        public void DeleteEmployee(int? employeeId)
        {
            try
            {
                this.empRepo.DeleteEmployee(employeeId);
            }
            catch (Exception)
            {
                throw new Exception("Exception Occured while Deleting Employee Data");
            }
        }
        //public EmployeeModel LoginEmployee(EmployeeLoginModel loginModel)
        //{
        //    try
        //    {
        //        return this.empRepo.LoginEmployee(loginModel);
        //    }
        //    catch(Exception)
        //    {
        //        throw new Exception("Exception Occured while Loging");
        //    }
        //}
    }
}
