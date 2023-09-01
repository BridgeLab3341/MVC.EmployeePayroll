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
    }
}
