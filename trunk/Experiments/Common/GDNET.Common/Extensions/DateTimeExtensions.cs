using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace GDNET.Common.Extensions
{
    public static class DateTimeExtensions
    {
        /// <summary>
        /// Parse a string to dateValue time.
        /// </summary>
        /// <param name="stringOfDate">String value to be parsed.</param>
        /// <param name="defaultValue">Default value to return in case of any errorException.</param>
        /// <returns></returns>
        public static DateTime Parse(this string stringOfDate, DateTime defaultValue)
        {
            return stringOfDate.Parse(defaultValue, DateTime.MinValue);
        }

        /// <summary>
        /// Parse a string to date time.
        /// </summary>
        /// <param name="stringOfDate">String value to be parsed.</param>
        /// <param name="defaultValue">Default value to return in case of any errorException.</param>
        /// <returns></returns>
        public static DateTime Parse(this string stringOfDate, DateTime defaultValue, DateTime minDate)
        {
            DateTime dateValue = defaultValue;
            try
            {
                dateValue = DateTime.Parse(stringOfDate.TrimWithHtmlSpaces().Trim());
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }

            if (dateValue < minDate)
            {
                dateValue = minDate;
            }
            return dateValue;
        }
    }
}
