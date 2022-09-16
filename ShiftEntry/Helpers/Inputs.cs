
namespace ShiftEntry.Helpers
{
    internal class Inputs
    {
        /// <summary>
        /// Ensures a valid string entry of length greater than one
        /// Will repeat the input <param name="phrase">phrase</param> if empty string entered
        /// <returns>String entered</returns>
        public static String GetString(string phrase)
        {
            var input = string.Empty;
            while (input.Length < 1)
            {
                Console.Write(phrase);
                input = Console.ReadLine();
            }

            return input;
        }

        /// <summary>
        /// Takes input from the user and attempts to parse as Decimal.
        /// If unable to parse to decimal it will repeat the input <param name="phrase">phrase</param>
        /// </summary>
        /// <returns>Decimal</returns>
        public static Decimal GetDecimal(string phrase)
        {
            decimal number = 0;
            while (true)
            {
                Console.Write(phrase);
                var input = Console.ReadLine();
                if (input != string.Empty && Decimal.TryParse(input, out number))
                {
                    return number;
                }
            }
        }

        /// <summary>
        /// Takes input from the user and attempts to parse as Integer.
        /// If unable to parse to int it will repeat the input <param name="phrase">phrase</param>
        /// </summary>
        /// <returns>int</returns>
        public static int GetInt(string phrase)
        {
            int number = 0;
            while (true)
            {
                Console.Write(phrase);
                var input = Console.ReadLine();
                if (input != string.Empty && Int32.TryParse(input, out number))
                {
                    return number;
                }
            }
        }

        /// <summary>
        /// Asks the user a <param name="phrase">question</param>
        /// and requires they enter a string starting with y or n.
        /// Only first letter is considered, capitalization is ignored.
        /// <returns>string "Y" or "N"</returns>
        public static string GetYesNo(string phrase)
        {
            string input = string.Empty;
            while (true)
            {
                Console.Write(phrase);
                input = Console.ReadLine();

                if (input != string.Empty && input.Substring(0, 1).ToUpper() == "Y")
                {
                    return "Y";
                }
                else if (input != string.Empty && input.Substring(0, 1).ToUpper() == "N")
                {
                    return "N";
                }
            }
        }
    }
}
