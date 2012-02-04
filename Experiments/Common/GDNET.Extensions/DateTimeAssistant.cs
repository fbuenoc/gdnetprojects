using System;
using System.Diagnostics;

namespace GDNET.Extensions
{
    public enum DateTimeDisplayStyles
    {
        /// <summary>
        /// Display datetime value in format dd/MM/yyyy
        /// </summary>
        DateOnly,
        /// <summary>
        /// Display datetime value in format dd/MM/yyyy HH:mm
        /// </summary>
        DateAndTime,
        /// <summary>
        /// Display datetime value in format dd/MM
        /// </summary>
        DayMonth,
    }

    public static class DateTimeAssistant
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

        /// <summary>
        /// Format a date to string. Return time only (HH:mm - 23:15) if the givem time equals today,
        /// otherwise return Date and time (dd/MM/yyyy HH:mm - 14/10/2010 16:25)
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToStringEx(this DateTime value)
        {
            string result = string.Empty;

            if (value.Date == DateTime.Today)
            {
                result = value.ToString("HH:mm");
            }
            else
            {
                result = value.ToString("dd/MM/yyyy HH:mm");
            }

            return result;
        }

        /// <summary>
        /// Format a date to string. Return time only (HH:mm - 23:15) if the givem time equals today,
        /// otherwise return Date and time (dd/MM/yyyy HH:mm - 14/10/2010 16:25)
        /// </summary>
        /// <param name="value"></param>
        /// <param name="style">
        /// If style is DateOnly, the output will be in format (dd/MM/yyyy - 14/10/2010)
        /// </param>
        /// <returns></returns>
        public static string ToStringEx(this DateTime value, DateTimeDisplayStyles style)
        {
            string result = string.Empty;

            if (value.Date == DateTime.Today)
            {
                result = value.ToString("HH:mm");
            }
            else
            {
                switch (style)
                {
                    default:
                    case DateTimeDisplayStyles.DateAndTime:
                        result = value.ToString("dd/MM/yyyy HH:mm");
                        break;
                    case DateTimeDisplayStyles.DateOnly:
                        result = value.ToString("dd/MM/yyyy");
                        break;
                    case DateTimeDisplayStyles.DayMonth:
                        result = value.ToString("dd/MM");
                        break;
                }
            }

            return result;
        }
    }
}
