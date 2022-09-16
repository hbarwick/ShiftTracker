namespace ShiftEntry
{
    internal class DateOperations
    {
        /// <summary>
        /// Prompts user for text input and parses to datetime, reprompting if unable to parse.
        /// </summary>
        /// <returns>Date portion as string in ShortDateString format: YYYY-MM-DD</returns>
        public static string EnterNewDate(string phrase)
        {
            Console.Write(phrase);
            string? DateEntry = Console.ReadLine();
            DateTime Date;
            while (DateEntry == String.Empty || !DateTime.TryParse(DateEntry, out Date))
            {
                Console.Write(phrase);
                DateEntry = Console.ReadLine();
            }
            string shortDate = Date.ToShortDateString();
            return shortDate;
        }

        /// <summary>
        /// Prompts user for text input and parses to datetime, reprompting if unable to parse.
        /// </summary>
        /// <returns>Time portion as string in ShortTimeString format: HH:MM:SS</returns>
        public static string EnterNewTime(string phrase)
        {
            Console.Write(phrase);
            string? TimeEntry = Console.ReadLine();
            DateTime Time;
            while (!DateTime.TryParse(TimeEntry, out Time))
            {
                Console.Write(phrase);
                TimeEntry = Console.ReadLine();
            }
            string shortTime = Time.ToShortTimeString();
            return shortTime;
        }

        /// <summary>
        /// Parses date string and time string together into a DateTime object.
        /// </summary>
        /// <param name="date">Date string</param>
        /// <param name="time">Time String</param>
        /// <returns>DateTime object</returns>
        public static DateTime ParseDateTime(string date, string time)
        {
            string dt = date + " " + time;
            DateTime parsedDt = DateTime.Parse(dt);
            return parsedDt;
        }

        /// <summary>
        /// Get todays date as string in format YYYY-MM-DD.
        /// </summary>
        /// <returns>date string YYYY-MM-DD</returns>
        public static string GetTodaysDate()
        {
            DateTime dateTime = DateTime.Now;
            string date = dateTime.ToShortDateString();
            return date;
        }
    }
}
