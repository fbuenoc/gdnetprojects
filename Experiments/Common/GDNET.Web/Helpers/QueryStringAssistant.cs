using System;
using System.Web;
using GDNET.Common.DesignByContract;

namespace GDNET.Web.Helpers
{
    public static class QueryStringAssistant
    {
        public static long? ParseInteger(string parameterName)
        {
            long? result = null;

            string parameterValue = HttpContext.Current.Request.QueryString[parameterName];
            if (!string.IsNullOrEmpty(parameterValue))
            {
                Int64 x;
                if (Int64.TryParse(parameterName, out x))
                {
                    result = x;
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
            QueryStringAssistant.GetValueAsString(name, out expectedResult);

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
        /// <typeparam name="T">Supported type: Enum, int/long, double/float, string</typeparam>
        /// <param name="name"></param>
        /// <param name="expectedResult"></param>
        /// <returns></returns>
        public static bool GetValueAs<T>(string name, out T expectedResult)
        {
            expectedResult = default(T);
            bool? result = null;

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
                    else if (typeof(T).FullName == typeof(string).FullName)
                    {
                        expectedResult = (T)Convert.ChangeType(rawValue, typeof(T));
                        result = true;
                    }
                    else if ((typeof(T).FullName == typeof(int).FullName) || (typeof(T).FullName == typeof(long).FullName))
                    {
                        long tempResult;
                        result = long.TryParse(rawValue, out tempResult);
                        expectedResult = (T)Convert.ChangeType(tempResult, typeof(T));
                    }
                    else if ((typeof(T).FullName == typeof(double).FullName) || (typeof(T).FullName == typeof(float).FullName))
                    {
                        double tempResult;
                        result = double.TryParse(rawValue, out tempResult);
                        expectedResult = (T)Convert.ChangeType(tempResult, typeof(T));
                    }

                    break;
                }
            }

            if (!result.HasValue)
            {
                ThrowException.NotSupportedException(string.Format("Not supported for type: {0}", typeof(T).FullName));
            }

            return result.Value;
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
                    if (typeof(T).BaseType.FullName == typeof(Enum).FullName)
                    {
                        expectedResult = (T)Enum.Parse(typeof(T), rawValue);
                        localResult = true;
                    }
                    break;
                }
            }

            return localResult;
        }
    }
}
