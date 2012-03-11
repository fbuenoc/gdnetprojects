using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using GDNET.Common.DesignByContract;
using GDNET.Common.Domain;
using GDNET.Common.Security.Services;

namespace GDNET.Extensions
{
    /// <summary>
    /// Styles to get substring
    /// </summary>
    public enum SubstringStyles
    {
        /// <summary>
        /// Used to get a substring with fixed length
        /// </summary>
        Fixed = 0,
        /// <summary>
        /// Used to get a substring until found a space, but not longer than EXTEND_SUBSTRING_LENGTH characters
        /// </summary>
        ToEndOfWord = 1
    }

    public static class StringAssistant
    {
        private const int EXTEND_SUBSTRING_LENGTH = 10;

        /// <summary>
        /// Uses to strip all html tags
        /// </summary>
        private static readonly Regex _htmlRegex = new Regex("<.*?>", RegexOptions.Compiled);

        /// <summary>
        /// Uses to get all integer numbers
        /// </summary>
        private static readonly Regex _integerRegex = new Regex("(\\d+)", RegexOptions.Compiled | RegexOptions.Multiline | RegexOptions.Singleline);

        /// <summary>
        /// Gets all numbers within a string
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static IList<Int32> GetNumbers(this string source)
        {
            IList<Int32> numbers = new List<Int32>();
            foreach (Match matchItem in _integerRegex.Matches(source))
            {
                numbers.Add(Convert.ToInt32(matchItem.Groups[1].Value));
            }
            return numbers;
        }

        /// <summary>
        /// Remove HTML from string with Regex.
        /// </summary>
        public static string StripHtmlTags(this string source)
        {
            return _htmlRegex.Replace(source, string.Empty);
        }

        /// <summary>
        /// Trim and removes all HTML spaces '&nbsp;'
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string TrimWithHtmlSpaces(this string source)
        {
            return source.Trim().Replace("&nbsp;", string.Empty);
        }

        #region Converting

        public static string ConvertToString(this object objectValue, Type objectType)
        {
            string result = null;
            ThrowException.ArgumentNullException(objectType, "objectType", "Type of object can not be null.");

            if (objectValue != null)
            {
                if (objectType.FullName == typeof(string).FullName)
                {
                    result = (string)objectValue;
                }
                else if (IsNumberic(objectType))
                {
                    result = objectValue.ToString();
                }
                else if (objectType.FullName == typeof(DateTime).FullName)
                {
                    result = ((DateTime)objectValue).ToBinary().ToString();
                }
                else if (objectType.FullName == typeof(bool).FullName)
                {
                    result = ((bool)objectValue).ToString();
                }
                else if (objectType.FullName == typeof(EncryptionOption).FullName)
                {
                    result = objectValue.ToString();
                }
                else if (objectType.GetInterface(typeof(IObjectSerialization).Name) != null)
                {
                    result = ((IObjectSerialization)objectValue).Serialize();
                }
                else
                {
                    ThrowException.NotSupportedException(string.Format("The type '{0}' is not supported.", objectType.FullName));
                }
            }

            return result;
        }

        public static object ConvertFromString(this string objectString, Type objectType)
        {
            object result = null;
            ThrowException.ArgumentNullException(objectType, "objectType", "Type of object can not be null.");

            if (!string.IsNullOrEmpty(objectString))
            {
                if (objectType.FullName == typeof(string).FullName)
                {
                    result = (object)objectString;
                }
                else if (IsNumberic(objectType))
                {
                    result = Convert.ChangeType(objectString, objectType);
                }
                else if (objectType.FullName == typeof(DateTime).FullName)
                {
                    result = Convert.ChangeType(DateTime.FromBinary(long.Parse(objectString)), objectType);
                }
                else if (objectType.FullName == typeof(EncryptionOption).FullName)
                {
                    result = objectString.ParseEnum<EncryptionOption>();
                }
                else if (objectType.GetInterface(typeof(IObjectSerialization).Name) != null)
                {
                    result = Activator.CreateInstance(objectType, objectString);
                }
                else
                {
                    ThrowException.NotSupportedException(string.Format("The type '{0}' is not supported.", objectType.FullName));
                }
            }

            return result;
        }

        private static bool IsNumberic(Type objectType)
        {
            return (objectType.FullName == typeof(int).FullName ||
                    objectType.FullName == typeof(long).FullName ||
                    objectType.FullName == typeof(double).FullName ||
                    objectType.FullName == typeof(decimal).FullName ||
                    objectType.FullName == typeof(float).FullName);
        }

        #endregion




        /// <summary>
        /// Get a substring from a source string
        /// </summary>
        /// <param name="sourceString"></param>
        /// <param name="length"></param>
        /// <param name="stripHtmlTags"></param>
        /// <param name="style"></param>
        /// <returns></returns>
        public static string GetSubstring(this string sourceString, int length, bool stripHtmlTags, SubstringStyles style)
        {
            string resultString = string.Empty;

            if (!string.IsNullOrEmpty(sourceString))
            {
                // Remove all HTML tags if selected
                if (stripHtmlTags)
                {
                    sourceString = HtmlAssistant.StripTagsRegexCompiled(sourceString);
                }

                // Correct the length if source string is shorter
                if (sourceString.Length < length)
                {
                    length = sourceString.Length;
                }

                switch (style)
                {
                    case SubstringStyles.Fixed:
                        resultString = sourceString.Substring(0, length);
                        break;

                    case SubstringStyles.ToEndOfWord:
                    default:
                        int counter = 0;
                        while (true)
                        {
                            if ((counter >= EXTEND_SUBSTRING_LENGTH) ||
                                (sourceString.Length <= length) ||
                                Char.IsWhiteSpace(sourceString[length]))
                            {
                                break;
                            }

                            counter += 1;
                            length += 1;
                        }
                        resultString = sourceString.Substring(0, length);
                        break;
                }
            }

            // Plus ... to the end of result string if its length is still not exceed length of the source string
            if (length < sourceString.Length)
            {
                resultString = string.Format("{0}...", resultString);
            }

            return resultString;
        }

        /// <summary>
        /// Protect email address
        /// </summary>
        /// <param name="emailAddress"></param>
        /// <returns></returns>
        public static string ProtectEmailAddress(this string emailAddress)
        {
            StringBuilder protectedEmailBuilder = new StringBuilder();
            if (!string.IsNullOrEmpty(emailAddress))
            {
                int indexOfAt = emailAddress.IndexOf("@");
                string firstPart = emailAddress.Substring(0, indexOfAt / 2);
                string secondPart = emailAddress.Substring(indexOfAt + 1);
                protectedEmailBuilder.AppendFormat("{0}...@{1}", firstPart, secondPart);
            }
            return protectedEmailBuilder.ToString();
        }

        /// <summary>
        /// Simple validation rule to determine the text is email address or not
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static bool IsEmailAddress(this string text)
        {
            bool localResult = false;
            if (!string.IsNullOrEmpty(text))
            {
                if (text.Contains("@") &&
                    text.Contains(".") &&
                    (text.IndexOf("@") > 0) &&
                    (text.IndexOf(".") > text.IndexOf("@") + 1) &&
                    (text.IndexOf(".") < text.Length))
                {
                    localResult = true;
                }
            }
            return localResult;
        }

        public static bool In(this string text, params string[] contaimers)
        {
            return contaimers.Contains(text);
        }
    }
}
