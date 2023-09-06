using CommonLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepoLayer.Interface
{
    public interface IEmpRepo
    {
        public string Create(EmployeeModel employee);
        public IEnumerable<EmployeeModel> GetAllEmployees();
        public EmployeeModel Update(EmployeeModel employee);
        public EmployeeModel GetEmployeeData(int? employeeId);
        public void DeleteEmployee(int? employeeId);
       // public EmployeeModel LoginEmployee(EmployeeLoginModel loginModel);
    }
}
