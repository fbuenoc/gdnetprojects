using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GDNET.Extensions
{
    /// <summary>
    /// Provides extension methods for string
    /// </summary>
    public static class StringExtensions
    {
        private const int EXTEND_SUBSTRING_LENGTH = 10;

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
                    sourceString = HtmlRemoval.StripTagsRegexCompiled(sourceString);
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
