using System.Web;
using GDNET.Common.Security.Services;
using WebFramework.Base.Common.Services;
using WebFramework.Domain.DefaultImpl;

namespace WebFramework.Base.Common.DefaultImpl
{
    public class NavigationService : INavigationService
    {
        private const string ReturnUrl = "ru";

        public string AddReturnUrl(string currentUrl)
        {
            string newUrl = string.Empty;
            string returnUrl = DomainServices.Encryption.Encrypt(HttpContext.Current.Request.Url.AbsoluteUri, EncryptionOption.Base64);

            string type1 = string.Format("?{0}=", ReturnUrl);
            string type2 = string.Format("&{0}=", ReturnUrl);

            if (currentUrl.Contains(type1) || currentUrl.Contains(type2))
            {
                int indexFrom = 0;
                int indexTo = 0;

                if (currentUrl.Contains(type1))
                {
                    indexFrom = currentUrl.IndexOf(type1) + type1.Length + 1;
                    indexTo = currentUrl.IndexOf("&", indexFrom);
                }
                if (currentUrl.Contains(type2))
                {
                    indexFrom = currentUrl.IndexOf(type2) + type2.Length + 1;
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

        public string AddParameter(string currentUrl, string paramName, string paramValue)
        {
            string newUrl = string.Empty;

            string type1 = string.Format("?{0}=", paramName);
            string type2 = string.Format("&{0}=", paramName);

            if (currentUrl.Contains(type1) || currentUrl.Contains(type2))
            {
                int indexFrom = 0;
                int indexTo = 0;

                if (currentUrl.Contains(type1))
                {
                    indexFrom = currentUrl.IndexOf(type1) + type1.Length + 1;
                    indexTo = currentUrl.IndexOf("&", indexFrom);
                }
                if (currentUrl.Contains(type2))
                {
                    indexFrom = currentUrl.IndexOf(type2) + type2.Length + 1;
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