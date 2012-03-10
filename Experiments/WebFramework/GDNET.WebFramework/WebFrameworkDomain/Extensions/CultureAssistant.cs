using System.Globalization;
using WebFramework.Domain.Common;

namespace WebFramework.Domain.Extensions
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
