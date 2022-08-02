using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace WorkMenegerSystem
{
    public class Employee
    {
        public int Id { get; set; }
        public int EmployeeNumber { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Pasition { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public decimal Salary { get; set; }
        public DateTime DateOfEmployment { get;  set; }
       
        public override string ToString()
        {
            return $"Id: {Id} Name: {Name} Surname: {Surname} Position: {Pasition}";
        }
    }
}



