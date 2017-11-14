using System;
using System.Globalization;

namespace MWApplicationAssignment
{
    public class Program
    {
        public static void Main(string[] args)
        {
            const int expectedNumberOfDates = 2;
            
            try
            {
                var dateRange = args.ConvertToDateRange(expectedNumberOfDates);
                Console.WriteLine(dateRange.ToString());
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (FormatException e)
            {
                Console.WriteLine($"{e.Message} Provide dates in correct format: {CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern}.");
            }           
        }
    }
}