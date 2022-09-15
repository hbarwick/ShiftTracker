
namespace ShiftEntry.Helpers
{
    internal class Inputs
    {
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
