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
        public EmployeeModel GetEmployeeData(int? id);
        public void DeleteEmployee(EmployeeModel model);

    }
}
