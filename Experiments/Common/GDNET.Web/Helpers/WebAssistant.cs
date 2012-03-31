using System;
using System.Text;
using System.Web;

namespace GDNET.Web.Helpers
{
    public static class WebAssistant
    {
        public static string GetCurrentDomain()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("{0}{1}{2}", HttpContext.Current.Request.Url.Scheme, Uri.SchemeDelimiter, HttpContext.Current.Request.Url.Host);

            if (HttpContext.Current.Request.Url.Port != 80)
            {
                sb.AppendFormat(":{0}", HttpContext.Current.Request.Url.Port);
            }

            return sb.ToString();
        }
    }
}
