using CommonLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interface
{
    public interface IEmpBusiness
    {
        public IEnumerable<EmployeeModel> GetAllEmployees();

        public string Create(EmployeeModel employee);
        public EmployeeModel Update(EmployeeModel employee);
        public EmployeeModel GetEmployeeData(int? employeeId);
        public void DeleteEmployee(int? employeeId);
        public EmployeeModel LoginEmployee(EmployeeLoginModel loginModel);
    }
}
