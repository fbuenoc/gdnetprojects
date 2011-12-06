using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Web;

namespace GDNET.Web.Helpers
{
    public sealed class QueryStringHelper
    {
        public static long? ParseInteger(string parameterName)
        {
            long? result = null;

            string parameterValue = HttpContext.Current.Request.QueryString[parameterName];
            if (!string.IsNullOrEmpty(parameterValue))
            {
                try
                {
                    result = Convert.ToInt64(parameterValue);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.ToString());
                }
            }

            return result;
        }

        /// <summary>
        /// Get value from query string and parse to the given type
        /// </summary>
        /// <param name="name"></param>
        /// <param name="expectedResult"></param>
        /// <returns></returns>
        public static string GetValueAsString(string name)
        {
            string expectedResult = string.Empty;
            GetValueAsString(name, out expectedResult);

            return expectedResult;
        }

        /// <summary>
        /// Get value from query string and parse to the given type
        /// </summary>
        /// <param name="name"></param>
        /// <param name="expectedResult"></param>
        /// <returns></returns>
        public static bool GetValueAsString(string name, out string expectedResult)
        {
            expectedResult = string.Empty;
            bool result = false;

            foreach (object key in HttpContext.Current.Request.QueryString.Keys)
            {
                if (key.ToString().Equals(name))
                {
                    expectedResult = HttpContext.Current.Request.QueryString[name];
                    result = true;
                    break;
                }
            }

            return result;
        }

        /// <summary>
        /// Get value from query string and parse to the given type.
        /// </summary>
        /// <typeparam name="T">Supported type: Enum, int/long, double/float</typeparam>
        /// <param name="name"></param>
        /// <param name="expectedResult"></param>
        /// <returns></returns>
        public static bool GetValueAs<T>(string name, out T expectedResult)
        {
            expectedResult = default(T);
            bool result = false;

            foreach (object key in HttpContext.Current.Request.QueryString.Keys)
            {
                if (key.ToString().Equals(name))
                {
                    string rawValue = HttpContext.Current.Request.QueryString[name];

                    if (typeof(T).BaseType.FullName == typeof(Enum).FullName)
                    {
                        expectedResult = (T)Enum.Parse(typeof(T), rawValue);
                        result = true;
                    }

                    if ((typeof(T).FullName == typeof(int).FullName) || (typeof(T).FullName == typeof(long).FullName))
                    {
                        long tempResult;
                        result = long.TryParse(rawValue, out tempResult);
                        expectedResult = (T)Convert.ChangeType(tempResult, typeof(T));
                    }

                    if ((typeof(T).FullName == typeof(double).FullName) || (typeof(T).FullName == typeof(float).FullName))
                    {
                        double tempResult;
                        result = double.TryParse(rawValue, out tempResult);
                        expectedResult = (T)Convert.ChangeType(tempResult, typeof(T));
                    }

                    break;
                }
            }

            return result;
        }

        /// <summary>
        /// Get value from query string and parse to the given type
        /// </summary>
        /// <param name="name"></param>
        /// <param name="expectedResult"></param>
        /// <returns></returns>
        public static bool GetValueAs<T>(string name, T defaultValue, out T expectedResult)
        {
            expectedResult = defaultValue;
            bool localResult = false;

            foreach (object key in HttpContext.Current.Request.QueryString.Keys)
            {
                if (key.ToString().Equals(name))
                {
                    string rawValue = HttpContext.Current.Request.QueryString[name];
                    try
                    {
                        if (typeof(T).BaseType.FullName == typeof(Enum).FullName)
                        {
                            expectedResult = (T)Enum.Parse(typeof(T), rawValue);
                            localResult = true;
                        }
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex);
                    }
                    break;
                }
            }

            return localResult;
        }
    }
}
