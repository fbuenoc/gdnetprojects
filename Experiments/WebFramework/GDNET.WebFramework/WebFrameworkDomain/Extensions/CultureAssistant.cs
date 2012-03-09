using System.Globalization;
using WebFrameworkDomain.Common;

namespace WebFrameworkDomain.Extensions
{
    public static class CultureAssistant
    {
        public static CultureInfo ToCultureInfo(this Culture entity)
        {
            string cultureCode = (entity == null) ? "en-US" : entity.CultureCode;
            return new CultureInfo(cultureCode);
        }
    }
}
