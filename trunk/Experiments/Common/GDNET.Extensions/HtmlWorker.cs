using System;
using System.Text.RegularExpressions;

namespace GDNET.Extensions
{
    public static class HtmlWorker
    {
        private static readonly Regex httpLinkRegex = new Regex("(http://[^ ]+)");
        private static readonly Regex httpsLinkRegex = new Regex("(https://[^ ]+)");

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
    }
}
