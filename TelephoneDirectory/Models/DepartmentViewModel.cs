using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TelephoneDirectory.Entities;

namespace TelephoneDirectory.Models
{
    public class DepartmentViewModel
    {
        public Department Department { get; set; }

        public DepartmentViewModel()
        {
            this.Department = new Department();
        }
    }
}