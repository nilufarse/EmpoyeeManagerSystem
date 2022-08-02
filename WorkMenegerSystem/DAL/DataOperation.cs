using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;


namespace WorkMenegerSystem.DAL
{
    public class DataOperation
    {
        public static List<Employee> Employees = new List<Employee>();
        public static List<WorkTime> WorkTimes = new List<WorkTime>();
      
        static DataOperation()
        {
            Employees = new List<Employee>();
            WorkTimes = new List<WorkTime>();
        }
    }
}
