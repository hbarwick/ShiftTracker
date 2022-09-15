using ShiftEntry.Controllers;
using ShiftEntry.Helpers;
using ShiftTrackerAPI.Models;
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
                    EnterShift();
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

        private static void EnterShift()
        {
            Console.WriteLine("---------------------------");
            Console.WriteLine("      Enter New Shift      ");
            Console.WriteLine("---------------------------\n");

            var choice = Inputs.GetYesNo("Use today's date?: ");

            string startDate;
            if (choice == "Y")
            {
                startDate = DateOperations.GetTodaysDate();
            }
            else
            {
                startDate = DateOperations.EnterNewDate("Enter shift date: ");
            }

            var startTime = DateOperations.EnterNewTime("Enter shift start time: ");

            choice = Inputs.GetYesNo("Shift ended on same day? ");
            string endDate;
            if (choice.Substring(0, 1).ToUpper() == "Y")
            {
                endDate = startDate;
            }
            else
            {
                endDate = DateOperations.EnterNewDate("Enter shift end date: ");
            }

            var endTime = DateOperations.EnterNewTime("Enter shift end time: ");

            var start = DateOperations.ParseDateTime(startDate, startTime);
            var end = DateOperations.ParseDateTime(endDate, endTime);
            var location = Inputs.GetString("Enter shift location: ");
            var pay = Inputs.GetDecimal("Enter hourly pay: ");

            Console.WriteLine(start);
            Console.WriteLine(end);
            Console.WriteLine(location);
            Console.WriteLine(pay);

        }

        private static void ViewShifts()
        {
            var shifts = APIInterface.GetShifts().Result;
            Reports.DisplayShifts(shifts);

        }
    }
}