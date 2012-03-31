using GDNET.Common.Helpers;
using WebFramework.Domain.Common;
using WebFramework.Domain.System;

namespace WebFramework.Domain.Constants
{
    public sealed class MetaInfos
    {
        public sealed class Common
        {
            public const string IsActive = "IsActive";
            public const string IsDeletable = "IsDeletable";
            public const string IsEditable = "IsEditable";
            public const string IsViewable = "IsViewable";
        }

        public sealed class ApplicationMeta
        {
            private static readonly Application defaultApp = Application.Factory.NewInstance();

            public static readonly string RootUrl = ExpressionAssistant.GetPropertyName(() => defaultApp.RootUrl);
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

        public sealed class PageMeta
        {
            private static readonly Page defaultPage = Page.Factory.NewInstance();

            public static readonly string Application = ExpressionAssistant.GetPropertyName(() => defaultPage.Application);
            public static readonly string Culture = ExpressionAssistant.GetPropertyName(() => defaultPage.Culture);
            public static readonly string IsDefault = ExpressionAssistant.GetPropertyName(() => defaultPage.IsDefault);
            public static readonly string Name = ExpressionAssistant.GetPropertyName(() => defaultPage.Name);
            public static readonly string UniqueName = ExpressionAssistant.GetPropertyName(() => defaultPage.UniqueName);
        }

        public sealed class TranslationMeta
        {
            private static readonly Translation defaultTranslation = Translation.Factory.NewInstance();

            public static readonly string Code = ExpressionAssistant.GetPropertyName(() => defaultTranslation.Code);
            public static readonly string Culture = ExpressionAssistant.GetPropertyName(() => defaultTranslation.Culture);
            public static readonly string Category = ExpressionAssistant.GetPropertyName(() => defaultTranslation.Category);
            public static readonly string IsRichTextEditor = ExpressionAssistant.GetPropertyName(() => defaultTranslation.IsRichTextEditor);
        }

        public sealed class WidgetMeta
        {
            public static readonly Widget defaultWidget = Widget.Factory.NewInstance();

            public static readonly string Code = ExpressionAssistant.GetPropertyName(() => defaultWidget.Code);
        }
    }
}
