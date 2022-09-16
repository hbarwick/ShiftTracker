using ShiftEntry.Controllers;
using ShiftEntry.Helpers;
using ShiftTrackerAPI.Models;

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
                    UpdateShift();
                    break;
                case "4":
                    DeleteShift();
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
            Console.Write("\nPress enter to return to Main Menu: ");
            Console.ReadLine();
            MainMenu();
        }


        private async static void EnterShift()
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
            if (choice == "Y")
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

            Shift shift = new Shift
            {
                Start = start,
                End = end,
                Pay = pay,
                Location = location
            };

            var task = APIInterface.PostShift(shift);
            task.Wait();
            Console.Write("\nShift post complete. Press enter to return to Main Menu: ");
            Console.ReadLine();
            MainMenu();
        }

        private static void UpdateShift()
        {
            var shift = SelectShift("update");
            MainMenu();
        }

        private static void DeleteShift()
        {
            var shift = SelectShift("delete");
            var choice = Inputs.GetYesNo("Are you sure you want to delete this shift?\nY to delete or N to return to main menu: ");
            if (choice == "Y")
            {
                var task = APIInterface.DeleteShift(shift.Id);
                task.Wait();
                Console.Write($"Shift {shift.Id} deleted, press enter to return to main menu: ");
                Console.ReadLine();
            }
            MainMenu();
        }


        private static Shift SelectShift(string task)
        {
            var shifts = APIInterface.GetShifts().Result;
            Reports.DisplayShifts(shifts);
            Console.WriteLine();

            var choice = Inputs.GetInt($"Enter ID of the shift to {task}: ");
            var selected = shifts.Where(x => x.Id == choice).ToList();
            
            while (selected.Count == 0)
            {
                Console.WriteLine("Invalid shift ID, please try again.");
                choice = Inputs.GetInt($"Enter ID of the shift to {task}: ");
                selected = shifts.Where(x => x.Id == choice).ToList();
            }

            Reports.DisplayShifts(selected);

            return selected[0];
        }
    }
}