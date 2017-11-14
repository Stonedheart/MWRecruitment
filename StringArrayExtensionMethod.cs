using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace MWApplicationAssignment
{
    public static class StringArrayExtensionMethod
    {

        public static DateRange ConvertToDateRange(this string[] stringArray, int expectedNumberOfDates)
        {
            if (!Equals(stringArray.Length, expectedNumberOfDates))
            {
                throw new ArgumentException("Incorrect number of arguments, please provide two dates.");
            }

            var firstDate = DateTime.Parse(stringArray[0]);
            var secondDate = DateTime.Parse(stringArray[1]);

            if (firstDate > secondDate)
            {
                throw new ArgumentException("The first date cannot be greater than the second one.");
            }
            
            return new DateRange(firstDate, secondDate);
        }
    }
}
