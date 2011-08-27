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
        /// Parse a string to date time.
        /// </summary>
        /// <param name="stringOfDate">String value to be parsed.</param>
        /// <param name="defaultValue">Default value to return in case of any error.</param>
        /// <returns></returns>
        public static DateTime Parse(this string stringOfDate, DateTime defaultValue)
        {
            try
            {
                return DateTime.Parse(stringOfDate.Trim());
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return defaultValue;
            }
        }
    }
}
