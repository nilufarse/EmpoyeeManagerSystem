using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using WorkMenegerSystem.DAL;

namespace WorkMenegerSystem.Meneger
{
    class EmployeeManager
    {
        static string datasource = "Data Source=DESKTOP-L6L8NUF;Initial Catalog=WorkMS;Integrated Security=True";
        static DataOperation DataOperation = new DataOperation();
        public static void AddEmployee()
        { 
            Employee employee = new Employee();
            Random random = new Random();
            employee.EmployeeNumber = random.Next(1, 100);
            Console.WriteLine("İşçi nömrəsini qeyd edin: ");
            employee.EmployeeNumber = int.Parse(Console.ReadLine());
            Console.WriteLine("İşçinin adını qeyd edin: ");
            employee.Name = Console.ReadLine();
            Console.WriteLine("İşçinin soyadını qeyd edin: ");
            employee.Surname = Console.ReadLine();
            Console.WriteLine("İşçinin vəzifəsini qeyd edin: ");
            employee.Pasition = Console.ReadLine();
            Console.WriteLine("İşçinin ünvanini qeyd edin: ");
            employee.Address = Console.ReadLine();
            Console.WriteLine("İşçinin əməkhaqqısını qeyd edin: ");
            employee.Salary = int.Parse(Console.ReadLine());
            Console.WriteLine("İşçinin telefonunu qeyd edin: ");
            employee.Phone = Console.ReadLine();
            Console.WriteLine("İşə giriş tarixini qeyd edin: ");
            employee.DateOfEmployment = Convert.ToDateTime(Console.ReadLine());
            SqlConnection connection = new SqlConnection(datasource);
            connection.Open();
            string insertQuery = "INSERT INTO [dbo].[Employee] ([Name], [Surname], [EmployeeNumber], [Pasition], [Phone], " +
                "[Address], [Salary], [DateOfEmployment]) VALUES (@Name, @Surname, @EmployeeNumber, @Pasition, @Phone, @Address, @Salary, @DateOfEmployment)";
            SqlCommand insertCommand = new SqlCommand(insertQuery, connection);
            insertCommand.Parameters.AddWithValue("@Name",employee.Name);
            insertCommand.Parameters.AddWithValue("@Surname", employee.Surname);
            insertCommand.Parameters.AddWithValue("@EmployeeNumber", employee.EmployeeNumber);
            insertCommand.Parameters.AddWithValue("@Pasition", employee.Pasition);
            insertCommand.Parameters.AddWithValue("@Phone", employee.Phone);
            insertCommand.Parameters.AddWithValue("@Address", employee.Address);
            insertCommand.Parameters.AddWithValue("@Salary", employee.Salary);
            insertCommand.Parameters.AddWithValue("@DateOfEmployment", employee.DateOfEmployment);
            insertCommand.ExecuteNonQuery();
            connection.Close();
        }
        public static void ReadEmployee(int? employeeNumber, string? adress, int? year, bool? late, int? workday, string position)
        {
            SqlDataReader sqlDataReader;
            SqlConnection sqlConnection = new SqlConnection(datasource);
            sqlConnection.Open();

            string selectQuery = "";
            if (employeeNumber != null && adress == null)
            {
            selectQuery= $"select EmployeeNumber,Name,Surname,Pasition,Phone,Address,Salary,DateOfEmployment from [dbo].[Employee] where EmployeeNumber = {employeeNumber};";
            }
            else if(adress == null && employeeNumber == null && year != null)
            {
                selectQuery = $"select EmployeeNumber,Name,Surname,Pasition,Phone,Address,Salary,DateOfEmployment from [dbo].[Employee] where DateOfEmployment like '{year}%';";
            }
            else if(adress == null && employeeNumber == null && year == null && late == true)
            {

                selectQuery = $"select [Employee].EmployeeNumber,Name,Surname,Pasition,Phone,Address,Salary,DateOfEmployment from [dbo].[Employee] inner join WorkTime on Employee.EmployeeNumber = WorkTime.EmployeeNumber where WorkTime.EntryTime>9 or (WorkTime.EntryTime=9 and WorkTime.EntryMinutes>0)";
            }
            else if (adress == null && employeeNumber == null && year == null && late == null && workday !=null)
            {
                selectQuery = $"select Employee.EmployeeNumber, Name, Surname, WorkTime.EntryTime, WorkTime.EntryMinutes, WorkTime.OutputTime, WorkTime.OutputMinutes  from [dbo].[Employee] inner join WorkTime on Employee.EmployeeNumber = WorkTime.EmployeeNumber where WorkTime.WorkDay = {workday} and WorkTime.OutputTime IS NOT NULL AND WorkTime.OutputMinutes IS NOT NULL;";
            }
            else if (adress == null && employeeNumber == null && year == null && late == null && workday == null && position != null)
            {
                selectQuery = $"select EmployeeNumber,Name,Surname,Pasition,Phone,Address,Salary,DateOfEmployment from [dbo].[Employee] where Pasition = '{position}';";
            }
            else
            {
                selectQuery= $"select EmployeeNumber,Name,Surname,Pasition,Phone,Address,Salary,DateOfEmployment from [dbo].[Employee] where [Address] = '{adress}';";
                
            }

            SqlCommand sqlCommand = new SqlCommand(selectQuery, sqlConnection);
            sqlDataReader = sqlCommand.ExecuteReader();

            while (sqlDataReader.Read())
            {
                Employee employee = new Employee();
                WorkTime workTime = new WorkTime();

                if (workday == null)
                {
                employee.Pasition = (string)sqlDataReader.GetValue(3);
                employee.Phone = (string)sqlDataReader.GetValue(4);
                employee.Address = (string)sqlDataReader.GetValue(5);
                employee.Salary = (decimal)sqlDataReader.GetValue(6);
                employee.DateOfEmployment = (DateTime)sqlDataReader.GetValue(7);
                }
                else
                {
                    workTime.EmployeeNumber = (int)sqlDataReader.GetValue(0);
                    workTime.EntryTime = (int)sqlDataReader.GetValue(3);
                    workTime.EntryMinutes = (int)sqlDataReader.GetValue(4);
                    workTime.OutputTime = (int)sqlDataReader.GetValue(5);
                    workTime.OutputMinutes = (int?)sqlDataReader.GetValue(6);
                }
                employee.EmployeeNumber = (int)sqlDataReader.GetValue(0);
                employee.Name = (string)sqlDataReader.GetValue(1);
                employee.Surname = (string)sqlDataReader.GetValue(2);


                DataOperation.WorkTimes.Add(workTime);
                DataOperation.Employees.Add(employee);
            }
            sqlConnection.Close();
            foreach (var item in DataOperation.Employees)
            {
                if(year != null)
                {
                    Console.WriteLine($"================{year} İlinə görə işçilər================");
                }
                else
                {
                    Console.WriteLine("=========================================================");
                }
                Console.WriteLine($"İşçi nömrəsi: {item.EmployeeNumber}");
                Console.WriteLine($"İşçinin adı: {item.Name}");
                Console.WriteLine($"İşçinin soyadı: {item.Surname}");
                if(workday == null)
                {
                Console.WriteLine($"İş sahəsi: {item.Pasition}");
                Console.WriteLine($"Telefon nömrəsi: {item.Phone}");
                Console.WriteLine($"Adresi: {item.Address}");
                Console.WriteLine($"Əməkhaqqı: {item.Salary}");
                Console.WriteLine($"İşə başlama tarixi: {item.DateOfEmployment}");
                }
                else
                {
                    foreach(var itemm in DataOperation.WorkTimes.Where(p => p.EmployeeNumber == item.EmployeeNumber))
                    {
                            Console.WriteLine( $"Giriş saatı {itemm.EntryTime}:{itemm.EntryMinutes}");
                            Console.WriteLine($"Çıxış saatı {itemm.OutputTime}:{itemm.OutputMinutes}");
                            Console.WriteLine($"Bir gün işdə olduğu ümumi saat {itemm.OutputTime-itemm.EntryTime} saat {itemm.OutputMinutes - itemm.EntryMinutes} deq");
                    }
                }
              
                Console.WriteLine("=========================================================");
            }
        }
        public static void UpdateEmployee()
        {
            Console.Write("Dəyişiklik etmək istədiyiniz işçinin işçi nömrəsini daxil edin: ");
            int number = Convert.ToInt32(Console.ReadLine());
            SqlConnection connection = new SqlConnection(datasource);
            connection.Open();
            EmployeeManager.ReadEmployee(number, null, null, null, null, null);
            Console.Write("İşçinin yeni adını daxil edin: ");
            string name = Console.ReadLine();
            Console.Write("İşçinin yeni əməkhaqqı əmsalını daxil edin: ");
            int salaryRate = Convert.ToInt32(Console.ReadLine());
            string updateQuery = $"UPDATE [dbo].[Employee]SET [Name] = '{name}', [Salary] = {salaryRate} WHERE Employee.EmployeeNumber = {number}";
            SqlCommand updateCommand = new SqlCommand(updateQuery, connection);
            updateCommand.ExecuteNonQuery();
            connection.Close();
            Console.Clear();
            Console.WriteLine("==========Yenilənmiş işçi məlumatları==========");
            EmployeeManager.ReadEmployee(number, null, null, null, null, null);
        }
        public static void DeleteEmployee()
        {
            Console.Write("Silmək istədiyiniz işçinin işçi nömrəsini daxil edin: ");
            int number = Convert.ToInt32(Console.ReadLine());
            EmployeeManager.ReadEmployee(number, null, null, null, null, null);
            Console.WriteLine("Silmək istədiyinizdən əminsiniz? Hə/Yox");
            string result = Console.ReadLine().ToLower();

            if(result == "hə")
            {
                SqlConnection connection = new SqlConnection(datasource);
                connection.Open();
                string deleteQuery = $"DELETE FROM [dbo].[Employee] WHERE Employee.EmployeeNumber = {number};";
                SqlCommand deleteCommand = new SqlCommand(deleteQuery, connection);
                deleteCommand.ExecuteNonQuery();
                connection.Close();
                Console.WriteLine("Silmə əməliyyatı ugurludur");
            }
        }
        public static void BackUpEmpoyees()
        {
            SqlConnection sqlConnection = new SqlConnection(datasource);
            sqlConnection.Open();
            try
            {
                string createTableForBackUpEmployees = "CREATE TABLE EmployeeBackUp (Id int, EmployeeNumber int not null, Name nvarchar(50) not null, Surname nvarchar(50) not null, Pasition nvarchar(50) not null, Phone int not null, Address nvarchar(50) not null, Salary decimal(18, 2) not null, DateOfEmployment datetime2(7) not null);";
                SqlCommand createTableCommand = new SqlCommand(createTableForBackUpEmployees, sqlConnection);
                createTableCommand.ExecuteNonQuery();
                string selectQuery = "SELECT [Name], [Surname], [EmployeeNumber], [Pasition], [Phone], [Address], [Salary], [DateOfEmployment] FROM [dbo].[Employee]";
                SqlCommand selectCommand = new SqlCommand(selectQuery, sqlConnection);
                SqlDataReader sqlDataReader = selectCommand.ExecuteReader();
                string insertQuery = "INSERT INTO [dbo].[Employee] ([Name], [Surname], [EmployeeNumber], [Pasition], [Phone], " +
                  "[Address], [Salary], [DateOfEmployment]) VALUES (@Name, @Surname, @EmployeeNumber, @Pasition, @Phone, @Address, @Salary, @DateOfEmployment)";
                SqlCommand insertCommand = new SqlCommand(insertQuery, sqlConnection);
                while (sqlDataReader.Read())
                {
                    insertCommand.Parameters.AddWithValue("@Name", (string)sqlDataReader.GetValue(0));
                    insertCommand.Parameters.AddWithValue("@Surname", (string)sqlDataReader.GetValue(1));
                    insertCommand.Parameters.AddWithValue("@EmployeeNumber", (int)sqlDataReader.GetValue(2));
                    insertCommand.Parameters.AddWithValue("@Pasition", (string)sqlDataReader.GetValue(3));
                    insertCommand.Parameters.AddWithValue("@Phone", (string)sqlDataReader.GetValue(4));
                    insertCommand.Parameters.AddWithValue("@Address", (string)sqlDataReader.GetValue(5));
                    insertCommand.Parameters.AddWithValue("@Salary", (decimal)sqlDataReader.GetValue(6));
                    insertCommand.Parameters.AddWithValue("@DateOfEmployment", (DateTime)sqlDataReader.GetValue(7));
                    insertCommand.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {
                sqlConnection.Close();
                sqlConnection.Open();
                string selectQuery = "SELECT [Name], [Surname], [EmployeeNumber], [Pasition], [Phone], [Address], [Salary], [DateOfEmployment] FROM [dbo].[Employee]";
                string insertQuery = "INSERT INTO [dbo].[Employee] ([Name], [Surname], [EmployeeNumber], [Pasition], [Phone], " +
                "[Address], [Salary], [DateOfEmployment]) VALUES (@Name, @Surname, @EmployeeNumber, @Pasition, @Phone, @Address, @Salary, @DateOfEmployment)";
                SqlCommand insertCommand = new SqlCommand(insertQuery, sqlConnection);
                SqlCommand selectCommand = new SqlCommand(selectQuery, sqlConnection);
                SqlDataReader sqlDataReader = selectCommand.ExecuteReader();
                sqlDataReader.Close();
                sqlDataReader = selectCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    insertCommand.Parameters.AddWithValue("@Name", (string)sqlDataReader.GetValue(0));
                    insertCommand.Parameters.AddWithValue("@Surname", (string)sqlDataReader.GetValue(1));
                    insertCommand.Parameters.AddWithValue("@EmployeeNumber", (int)sqlDataReader.GetValue(2));
                    insertCommand.Parameters.AddWithValue("@Pasition", (string)sqlDataReader.GetValue(3));
                    insertCommand.Parameters.AddWithValue("@Phone", (string)sqlDataReader.GetValue(4));
                    insertCommand.Parameters.AddWithValue("@Address", (string)sqlDataReader.GetValue(5));
                    insertCommand.Parameters.AddWithValue("@Salary", (decimal)sqlDataReader.GetValue(6));
                    insertCommand.Parameters.AddWithValue("@DateOfEmployment", (DateTime)sqlDataReader.GetValue(7));
                    insertCommand.ExecuteNonQuery();
                }
            }
            sqlConnection.Close();
        }
    }
}
