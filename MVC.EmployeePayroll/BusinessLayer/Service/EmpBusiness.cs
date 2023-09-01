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
    }
}
