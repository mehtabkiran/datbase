using System;
using System.Collections.Generic;

namespace databasewithviews.Models
{
    public partial class Employee
    {
        public int EmpId { get; set; }
        public string EmpName { get; set; }
        public int EmpAge { get; set; }
        public string EmpScale { get; set; }
        public decimal EmpSalary { get; set; }
    }
}
