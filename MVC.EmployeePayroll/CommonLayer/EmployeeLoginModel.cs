using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CommonLayer
{
    public class EmployeeLoginModel
    {
        [Required(ErrorMessage ="{0} is required")]
        public int EmployeeId { get; set;}
        [Required(ErrorMessage ="{0} is required")]
        [DataType(DataType.Password)]
        public string Name { get; set;}
    }   
}
