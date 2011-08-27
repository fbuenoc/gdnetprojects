using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace GDNET.Common.Extensions
{
    public static class StringExtensions
    {
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
    }
}
