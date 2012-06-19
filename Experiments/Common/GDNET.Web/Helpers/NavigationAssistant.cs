using System.Web;
using GDNET.Extensions;

namespace GDNET.Web.Helpers
{
    public static class NavigationAssistant
    {
        public const string ReturnUrl = "ru";

        public static string CurrentUrl
        {
            get { return HttpContext.Current.Request.Url.AbsoluteUri; }
        }

        public static string AddReturnUrl(string currentUrl)
        {
            string newUrl = string.Empty;
            string returnUrl = Base64Assistant.Encrypt(HttpContext.Current.Request.Url.AbsoluteUri);

            string type1 = string.Format("?{0}=", ReturnUrl);
            string type2 = string.Format("&{0}=", ReturnUrl);

            if (currentUrl.Contains(type1) || currentUrl.Contains(type2))
            {
                int indexFrom = 0;
                int indexTo = 0;

                if (currentUrl.Contains(type1))
                {
                    indexFrom = currentUrl.IndexOf(type1) + type1.Length;
                    indexTo = currentUrl.IndexOf("&", indexFrom);
                }
                if (currentUrl.Contains(type2))
                {
                    indexFrom = currentUrl.IndexOf(type2) + type2.Length;
                    indexTo = currentUrl.IndexOf("&", indexFrom);
                }

                newUrl = string.Format("{0}{1}", currentUrl.Substring(0, indexFrom), returnUrl);
                if (indexTo > indexFrom)
                {
                    newUrl = string.Format("{0}{1}", newUrl, currentUrl.Substring(indexTo));
                }
            }
            else
            {
                string theFormat = currentUrl.Contains("?") ? "{0}&{1}={2}" : "{0}?{1}={2}";
                newUrl = string.Format(theFormat, currentUrl, ReturnUrl, returnUrl);
            }

            return newUrl;
        }

        public static string AddParameter(string currentUrl, string paramName, object paramValue)
        {
            string paramValueString = (paramValue == null) ? string.Empty : paramValue.ToString();
            return NavigationAssistant.AddParameter(currentUrl, paramName, paramValueString);
        }

        public static string AddParameter(string currentUrl, string paramName, string paramValue)
        {
            if (string.IsNullOrEmpty(paramName))
            {
                return currentUrl;
            }

            string newUrl = string.Empty;
            string type1 = string.Format("?{0}=", paramName);
            string type2 = string.Format("&{0}=", paramName);

            if (currentUrl.Contains(type1) || currentUrl.Contains(type2))
            {
                int indexFrom = 0;
                int indexTo = 0;

                if (currentUrl.Contains(type1))
                {
                    indexFrom = currentUrl.IndexOf(type1) + type1.Length;
                    indexTo = currentUrl.IndexOf("&", indexFrom);
                }
                if (currentUrl.Contains(type2))
                {
                    indexFrom = currentUrl.IndexOf(type2) + type2.Length;
                    indexTo = currentUrl.IndexOf("&", indexFrom);
                }

                newUrl = string.Format("{0}{1}", currentUrl.Substring(0, indexFrom), paramValue);
                if (indexTo > indexFrom)
                {
                    newUrl = string.Format("{0}{1}", newUrl, currentUrl.Substring(indexTo));
                }
            }
            else
            {
                string theFormat = currentUrl.Contains("?") ? "{0}&{1}={2}" : "{0}?{1}={2}";
                newUrl = string.Format(theFormat, currentUrl, paramName, paramValue);
            }

            return newUrl;
        }
    }
}