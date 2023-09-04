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
            catch (Exception ) 
            {
                throw ;
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
                throw;
            }
        }
        public EmployeeModel Update(EmployeeModel employee)
        {
            try
            {
                return this.empRepo.Update(employee);
            }
            catch (Exception )
            {
                throw;
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
                throw;
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
                throw;
            }
        }
    }
}
