using bijaypracticle2.Properties;
using System;

namespace bijaypracticle2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CRUDoperation c1 = new CRUDoperation();
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("\n===== CRUD Operations Menu =====");
                Console.WriteLine("1. Create Table");
                Console.WriteLine("2. Insert Record");
                Console.WriteLine("3. Update Record");
                Console.WriteLine("4. Delete Record");
                Console.WriteLine("5. Display All Records");
                Console.WriteLine("6. Display Male Users from Nepal");
                Console.WriteLine("7. Exit");
                Console.Write("Enter your choice (1-7): ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        c1.CreateTable();
                        break;
                    case "2":
                        c1.InsertRecord();
                        break;
                    case "3":
                        c1.UpdateRecord();
                        break;
                    case "4":
                        c1.DeleteRecord();
                        break;
                    case "5":
                        c1.DisplayAllRecords();
                        break;
                    case "6":
                        c1.DisplayMaleUsersFromNepal();
                        break;
                    case "7":
                        exit = true;
                        Console.WriteLine("Exiting program...");
                        break;
                    default:
                        Console.WriteLine("Invalid choice! Please enter a number between 1 and 7.");
                        break;
                }
            }
        }
    }
}
