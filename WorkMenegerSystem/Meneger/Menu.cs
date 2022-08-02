using System;
using System.Collections.Generic;
using System.Text;

namespace WorkMenegerSystem.Meneger
{
    class Menu
    {
        public static void menu()
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Console.WriteLine("========================================================");
            Console.WriteLine("Axtarış menyusu");
            Console.WriteLine("1. Bir işçinin məlumatlarının göstərilməsi");
            Console.WriteLine("2. Vəzifəyə görə axtarış ");
            Console.WriteLine("3. İşə qebul olunan işçilərin sayının illər üzrə bölgüsü");
            Console.WriteLine("4. İşə gec gələn işçilərin siyahısı ");
            Console.WriteLine("5. Müəyyən bir günün əlavə iş qeydlərinin sadalanması ");
            Console.WriteLine("=========================================================");
            Console.WriteLine("Yenilənmə menyusu");
            Console.WriteLine("6. Yeni işçinin əlave edilməsi ");
            Console.WriteLine("7. İşçi məlumatlarının yenilənməsi");
            Console.WriteLine("8. İşçinin işə girişi");
            Console.WriteLine("9. İşçinin işdən çıxışı ");
            Console.WriteLine("10. İşçi məlumatlarının dosyadan silinməsi ");
            Console.WriteLine("========================================================");
            Console.Write("Etmək istədiyiniz əməliyyat nömrəsini seçin: ");
            int secim = int.Parse(Console.ReadLine());
            switch (secim)
            {
                case 1:
                    string iscontinue = "hə";
                    do
                    {
                    Console.Write("İşçi nömrəsini qeyd edin: ");
                    int number = Convert.ToInt32(Console.ReadLine());

                    EmployeeManager.ReadEmployee(number, null, null, null, null, null);
                        Console.WriteLine("Davam etmək istəyirsiniz? ");
                        iscontinue = Console.ReadLine().ToLower();
                    } while (iscontinue == "hə");
                    Menu.menu();
                    break;
                case 2:
                    do
                    {
                        Console.Write("İşçi vəzifəsini qeyd edin: ");
                        string position = Console.ReadLine();

                        EmployeeManager.ReadEmployee(null, null, null, null, null, position);
                        Console.WriteLine("Davam etmək istəyirsiniz? ");
                        iscontinue = Console.ReadLine().ToLower();
                    } while (iscontinue == "hə");
                    Menu.menu();
                    break;
                case 3:
                    do
                    {
                        Console.Write("İl daxil edin 'yyyy': ");
                        int year = Convert.ToInt32(Console.ReadLine());
                        EmployeeManager.ReadEmployee(null, null, year, null, null, null);
                        Console.WriteLine("Davam etmək istəyirsiniz? ");
                        iscontinue = Console.ReadLine().ToLower();
                    } while (iscontinue == "hə");
                    Menu.menu();
                    break;
                        case 4:
                    do
                    {
                        EmployeeManager.ReadEmployee(null, null, null, true, null, null);
                        Console.WriteLine("Davam etmək istəyirsiniz? ");
                        iscontinue = Console.ReadLine().ToLower();
                    } while (iscontinue == "hə");
                    Menu.menu();
                    break;
                    case 5:
                    do
                    {
                        Console.Write("Gün daxil edin: ");
                        int day = Convert.ToInt32(Console.ReadLine());
                        EmployeeManager.ReadEmployee(null, null, null, null, day, null);
                        Console.WriteLine("Davam etmək istəyirsiniz? ");
                        iscontinue = Console.ReadLine().ToLower();
                    } while (iscontinue == "hə");
                    Menu.menu();
                    break;
                    case 6:
                    do
                    {
                        EmployeeManager.AddEmployee();
                        Console.WriteLine("Davam etmek isteyirsiniz? ");
                        iscontinue = Console.ReadLine().ToLower();
                    } while (iscontinue == "hə");
                    Menu.menu();
                    break;
                case 7:
                    do
                    {
                        EmployeeManager.UpdateEmployee();
                        Console.WriteLine("Davam etmək istəyirsiniz? ");
                        iscontinue = Console.ReadLine().ToLower();
                    } while (iscontinue == "hə");
                    Menu.menu();
                    break;
                    case 8:
                    WorkTimeManager.EntryEmployeeTimes();
                    Menu.menu();
                    break;
                case 9:
                    WorkTimeManager.OutputEmployeeTimes();
                    Menu.menu();
                    break;
                case 10:
                    do
                    {
                        EmployeeManager.DeleteEmployee();
                        Console.WriteLine("Davam etmək istəyirsiniz? ");
                        iscontinue = Console.ReadLine().ToLower();
                    } while (iscontinue == "hə");
                    Menu.menu();
                    break;
                default:
                    break;
            }
        }
    }
}
