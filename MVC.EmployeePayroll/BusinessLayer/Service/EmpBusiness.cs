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
        public EmployeeModel GetEmployeeData(int? id)
        {
            try
            {
                return this.empRepo.GetEmployeeData(id);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void DeleteEmployee(int? id)
        {
            try
            {
                this.empRepo.DeleteEmployee(id);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
