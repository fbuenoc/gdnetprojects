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
            return stringOfDate.Parse(defaultValue, defaultValue);
        }

        /// <summary>
        /// Parse a string to date time.
        /// </summary>
        /// <param name="stringOfDate">String value to be parsed.</param>
        /// <param name="defaultValue">Default value to return in case of any errorException.</param>
        /// <returns></returns>
        public static DateTime Parse(this string stringOfDate, DateTime defaultValue, DateTime minDate)
        {
            if (defaultValue < minDate)
            {
                defaultValue = minDate;
            }
            DateTime dateValue = defaultValue;

            try
            {
                dateValue = DateTime.Parse(stringOfDate.TrimWithHtmlSpaces().Trim());

                if (dateValue < minDate)
                {
                    dateValue = minDate;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }

            return dateValue;
        }
    }
}
