using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using WorkMenegerSystem.DAL;

namespace WorkMenegerSystem.Meneger
{
   public class WorkTimeManager
    {
        static string datasource = "Data Source=DESKTOP-L6L8NUF;Initial Catalog=WorkMS;Integrated Security=True";
        static DataOperation DataOperation = new DataOperation();
        public static void EntryEmployeeTimes()
        {
            WorkTime workTime = new WorkTime();
            Console.WriteLine("İşçi nömrəsini qeyd edin: ");
            workTime.EmployeeNumber = Convert.ToInt32(Console.ReadLine());
            SqlConnection connection = new SqlConnection(datasource);
            connection.Open();
            Console.WriteLine("İş günü");
            workTime.WorkDay = DateTime.Now.Day;
            Console.WriteLine("İşə giriş saati:");
            workTime.EntryTime = DateTime.Now.Hour;
            Console.WriteLine("İşə giriş deqiqesi: ");
            workTime.EntryMinutes = DateTime.Now.Minute;
            Console.WriteLine("İşə giriş saniyesi: ");
            workTime.EntrySeconds = DateTime.Now.Second;
            string insertQuery = "INSERT INTO [dbo].[WorkTime] ([EmployeeNumber], [WorkDay], [EntryTime], [EntryMinutes], [EntrySeconds])" +
                " VALUES  (@EmployeeNumber, @WorkDay, @EntryTime, @EntryMinutes, @EntrySeconds)";

            SqlCommand insertCommand = new SqlCommand(insertQuery, connection);
            insertCommand.Parameters.AddWithValue("@EmployeeNumber", workTime.EmployeeNumber);
            insertCommand.Parameters.AddWithValue("@WorkDay", workTime.WorkDay);
            insertCommand.Parameters.AddWithValue("@EntryTime", workTime.EntryTime);
            insertCommand.Parameters.AddWithValue("@EntryMinutes", workTime.EntryMinutes);
            insertCommand.Parameters.AddWithValue("@EntrySeconds", workTime.EntrySeconds);
            insertCommand.ExecuteNonQuery();
            connection.Close();
        }
        public static void OutputEmployeeTimes()
        {
            SqlConnection connection = new SqlConnection(datasource);
            connection.Open();
            WorkTime workTime = new WorkTime();
            Console.WriteLine("İşçi nömrəsini qeyd edin: ");
            workTime.EmployeeNumber = Convert.ToInt32(Console.ReadLine());
            workTime.WorkDay = DateTime.Now.Day;
            Console.WriteLine("İşdən çıxış saatını:");
            workTime.OutputTime = DateTime.Now.Hour;
            Console.WriteLine("İşdən çıxış dəqiqəsini: ");
            workTime.OutputMinutes = DateTime.Now.Minute;
            Console.WriteLine("İşdən çıxış saniyəsini: ");
            workTime.OutputSeconds = DateTime.Now.Second;
            string updateQuery = $"UPDATE [dbo].[WorkTime] SET  [OutputTime] = {workTime.OutputTime}, [OutputMinutes] = {workTime.OutputMinutes}, [OutputSeconds] = {workTime.OutputSeconds}  WHERE [EmployeeNumber] = {workTime.EmployeeNumber}";
            SqlCommand updateCommand = new SqlCommand(updateQuery, connection);
            updateCommand.ExecuteNonQuery();
            connection.Close();
        }
    }
}

