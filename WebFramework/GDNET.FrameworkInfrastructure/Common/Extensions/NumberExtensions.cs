using System.Web.Mvc;
using GDNET.FrameworkInfrastructure.Services;
using GDNET.Utils;

namespace GDNET.FrameworkInfrastructure.Common.Extensions
{
    public static class NumberExtensions
    {
        public static string Format(this HtmlHelper htmlHelper, int? value)
        {
            return NumberAssistant.Format(value);
        }

        public static string Format(this HtmlHelper htmlHelper, int? value, string keywordOnZero)
        {
            if (!value.HasValue || value.Value == 0)
            {
                return WebFrameworkServices.Translation.GetByKeyword(keywordOnZero);
            }

            return NumberAssistant.Format(value);
        }

        public static string Format(this HtmlHelper htmlHelper, double? value)
        {
            return NumberAssistant.Format(value);
        }

        public static string Format(this HtmlHelper htmlHelper, double? value, string keywordOnZero)
        {
            if (!value.HasValue || value.Value == 0)
            {
                return WebFrameworkServices.Translation.GetByKeyword(keywordOnZero);
            }

            return NumberAssistant.Format(value);
        }
    }
}
