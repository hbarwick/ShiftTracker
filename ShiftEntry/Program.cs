using ShiftEntry.Controllers;
using System.Security.Cryptography.X509Certificates;

namespace ShiftEntry
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MainMenu();   
        }

        private static void MainMenu()
        {
            Console.WriteLine("---------------------------");
            Console.WriteLine("         MAIN MENU         ");
            Console.WriteLine("---------------------------\n");
            Console.WriteLine("0 - Exit Application");
            Console.WriteLine("1 - View Shifts");
            Console.WriteLine("2 - Enter Shift");
            Console.WriteLine("3 - Update Shift");
            Console.WriteLine("4 - Delete Shift");

            ChooseOption();
        }

        private static void ChooseOption()
        {
        Console.Write("\nEnter option number: ");
        var choice = Console.ReadLine();
            switch (choice)
            {
                case "0":
                    break;
                case "1":
                    ViewShifts();
                    break;
                case "2":
                    break;
                case "3":
                    break;
                case "4":
                    break;
                default:
                    Console.WriteLine("Invalid entry, please try again");
                    ChooseOption();
                    break;
            }
        }

        private static void ViewShifts()
        {
            var shifts = APIInterface.GetShifts().Result;
            Reports.DisplayShifts(shifts);

        }
    }
}