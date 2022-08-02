using System;
using System.Collections.Generic;
using System.Text;

namespace WorkMenegerSystem
{
    public class WorkTime
    {
        public int Id { get; set; }
        public Employee Employee { get; set; }
        public int WorkDay { get; set; }
        public int EmployeeNumber { get; set; }
        public int EntryTime { get; set; }
        public int EntryMinutes { get; set; }
        public int EntrySeconds { get; set; }
        public int? OutputTime { get; set; }
        public int? OutputMinutes { get; set; }
        public int? OutputSeconds { get;  set; }
    
    }
}



