using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesTest.Common.DTO
{
  public  class EmployeesDTO
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Fname { get; set; }

        [Required]
        [StringLength(50)]
        public string Lname { get; set; }


        public string fullname
        {
            get;
            set;

        }
    }
}
