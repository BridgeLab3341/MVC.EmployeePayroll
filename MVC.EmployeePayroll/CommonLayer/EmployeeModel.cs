using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CommonLayer
{
    public class EmployeeModel
    {
        public int EmployeeId { get; set; }
        [Required(ErrorMessage = "{0} Should be given")]
        [StringLength(10, MinimumLength = 1, ErrorMessage = "Last name should be 1 to 10 characters")]
        public string Name { get; set; }
        [Required(ErrorMessage ="{0} Should be Select")]
        public string ProfileImage { get; set; }
        [Required(ErrorMessage = "{0} Should Select")]
        public string Gender { get; set; }
        [Required(ErrorMessage = "{0} Should Select")]
        public string Department { get; set; }
        [Required(ErrorMessage = "{0} Should be given")]
        [Range(1, 100000000)]

        public Decimal Salary { get; set; }
        [Required(ErrorMessage = "{0} should be given")]

        public DateTime StartDate { get; set; }
        [Required(ErrorMessage = "{0} should be given")]
        public string Notes { get; set; }
    }
}
