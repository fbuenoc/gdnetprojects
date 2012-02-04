using System.Text.RegularExpressions;

namespace GDNET.Extensions
{
    public static class HtmlAssistant
    {
        private static readonly Regex httpLinkRegex = new Regex("(http://[^ ]+)");
        private static readonly Regex httpsLinkRegex = new Regex("(https://[^ ]+)");

        /// <summary>
        /// Compiled regular expression for performance.
        /// </summary>
        private static Regex htmlRegex = new Regex("<.*?>", RegexOptions.Compiled);

        /// <summary>
        /// Auto create links for plain text
        /// </summary>
        /// <param name="plainText"></param>
        /// <returns></returns>
        public static string MakeClickable(string plainText)
        {
            string textClickable = string.Empty;
            if (!string.IsNullOrEmpty(plainText))
            {
                textClickable = httpLinkRegex.Replace(plainText, "<a href='$1'>$1</a>");
                textClickable = httpsLinkRegex.Replace(textClickable, "<a href='$1'>$1</a>");
            }
            return textClickable;
        }

        ///
        /// Methods to remove HTML from strings.
        /// Visit http://dotnetperls.com/remove-html-tags for details.
        ///

        /// <summary>
        /// Remove HTML from string with Regex.
        /// </summary>
        public static string StripTagsRegex(string source)
        {
            if (string.IsNullOrEmpty(source))
            {
                return string.Empty;
            }
            return Regex.Replace(source, "<.*?>", string.Empty);
        }

        /// <summary>
        /// Remove HTML from string with compiled Regex.
        /// </summary>
        public static string StripTagsRegexCompiled(string source)
        {
            if (string.IsNullOrEmpty(source))
            {
                return string.Empty;
            }
            return htmlRegex.Replace(source, string.Empty);
        }

        /// <summary>
        /// Remove HTML tags from string using char array.
        /// </summary>
        public static string StripTagsCharArray(string source)
        {
            char[] array = new char[source.Length];
            int arrayIndex = 0;
            bool inside = false;

            for (int i = 0; i < source.Length; i++)
            {
                char let = source[i];
                if (let == '<')
                {
                    inside = true;
                    continue;
                }
                if (let == '>')
                {
                    inside = false;
                    continue;
                }
                if (!inside)
                {
                    array[arrayIndex] = let;
                    arrayIndex++;
                }
            }
            return new string(array, 0, arrayIndex);
        }
    }
}
