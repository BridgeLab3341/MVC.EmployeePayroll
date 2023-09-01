using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLayer
{
    public class EmployeeModel
    {
        public string Name { get; set; }
        public string ProfileImage { get; set; }
        public string Gender { get; set; }
        public string Department { get; set; }
        public Decimal Salary { get; set; }
        public DateTime StartDate { get; set; }
        public string Notes { get; set; }
    }
}
