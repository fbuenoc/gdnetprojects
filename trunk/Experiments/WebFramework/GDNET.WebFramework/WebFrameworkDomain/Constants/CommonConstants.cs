using GDNET.Common.Helpers;
using WebFrameworkDomain.Common;

namespace WebFrameworkDomain.Constants
{
    public sealed class CommonConstants
    {
        public const string CultureCodeDefault = "en-US";

        public sealed class ApplicationMeta
        {
            private static readonly Application defaultApp = Application.Factory.NewInstance();

            public static readonly string RootUrl = ExpressionAssistant.GetPropertyName<string>(() => defaultApp.RootUrl);
        }

        public sealed class ContentItemMeta
        {
            private static readonly ContentItem defaultContentItem = ContentItem.Factory.NewInstance();

            public static readonly string ContentType = ExpressionAssistant.GetPropertyName(() => defaultContentItem.ContentType);
        }

        public sealed class ContentTypeMeta
        {
            private static readonly ContentType defaultContentType = ContentType.Factory.NewInstance();

            public static readonly string Code = ExpressionAssistant.GetPropertyName(() => defaultContentType.Code);
            public static readonly string TypeName = ExpressionAssistant.GetPropertyName(() => defaultContentType.TypeName);
        }

        public sealed class CultureMeta
        {
            private static readonly Culture defaultCulture = Culture.Factory.NewInstance();

            public static readonly string CultureCode = ExpressionAssistant.GetPropertyName(() => defaultCulture.CultureCode);
            public static readonly string IsDefault = ExpressionAssistant.GetPropertyName(() => defaultCulture.IsDefault);
        }

        public sealed class ListValueMeta
        {
            private static readonly ListValue defaultListValue = ListValue.Factory.NewInstance();

            public static readonly string Name = ExpressionAssistant.GetPropertyName(() => defaultListValue.Name);
            public static readonly string Parent = ExpressionAssistant.GetPropertyName(() => defaultListValue.Parent);
        }

        public sealed class TranslationMeta
        {
            private static readonly Translation defaultTranslation = Translation.Factory.NewInstance();

            public static readonly string Code = ExpressionAssistant.GetPropertyName(() => defaultTranslation.Code);
            public static readonly string Culture = ExpressionAssistant.GetPropertyName(() => defaultTranslation.Culture);
        }

    }
}
