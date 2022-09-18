using ConsoleTableExt;
using ShiftTrackerAPI.Models;

namespace ShiftEntry.Helpers
{
    internal class Reports
    {
        public static void DisplayShifts(List<Shift> shifts)
        {
            var tableData = new List<List<object>>();

            foreach (var shift in shifts)
            {
                tableData.Add(new List<object> { shift.Id, shift.Start, shift.End, shift.Pay, shift.Minutes, shift.Location });
            }
            ConsoleTableBuilder
                .From(tableData)
                .WithColumn("Id", "Shift Start", "Shift End", "Pay", "Minutes", "Location")
                .ExportAndWriteLine();
        }
    }
}
