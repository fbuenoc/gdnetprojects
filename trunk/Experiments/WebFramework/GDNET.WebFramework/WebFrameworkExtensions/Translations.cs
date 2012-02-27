namespace WebFrameworkExtensions
{
    public static class Translations
    {
        public static class System
        {
            public static string Category
            {
                get { return TranslationAssistant.Translate("ApplicationCategories.SysTranslation.Category"); }
            }

            public static string CreatedAt
            {
                get { return TranslationAssistant.Translate("ApplicationCategories.SysTranslation.CreatedAt"); }
            }

            public static string CreatedBy
            {
                get { return TranslationAssistant.Translate("ApplicationCategories.SysTranslation.CreatedBy"); }
            }

            public static string DeleteAndContinue
            {
                get { return TranslationAssistant.Translate("ApplicationCategories.SysTranslation.DeleteAndContinue"); }
            }

            public static string DeleteConfirmation
            {
                get { return TranslationAssistant.Translate("ApplicationCategories.SysTranslation.DeleteConfirmation"); }
            }

            public static string DeleteConfirmationXYZ(string xyz)
            {
                string confirmationXYZ = TranslationAssistant.Translate("ApplicationCategories.SysTranslation.DeleteConfirmationXYZ");
                return string.Format(confirmationXYZ, xyz);
            }

            public static string DetailOfXYZ(string xyz)
            {
                string detailXYZ = TranslationAssistant.Translate("ApplicationCategories.SysTranslation.DetailOfXYZ");
                return string.Format(detailXYZ, xyz);
            }

            public static string Name
            {
                get { return TranslationAssistant.Translate("ApplicationCategories.SysTranslation.Name"); }
            }

            public static string Description
            {
                get { return TranslationAssistant.Translate("ApplicationCategories.SysTranslation.Description"); }
            }

            public static string SaveAndContinue
            {
                get { return TranslationAssistant.Translate("ApplicationCategories.SysTranslation.SaveAndContinue"); }
            }

            public static string Statut
            {
                get { return TranslationAssistant.Translate("ApplicationCategories.SysTranslation.Statut"); }
            }
        }

        public static class EntityNames
        {
            public static string Application
            {
                get { return TranslationAssistant.Translate("ApplicationCategories.SysTranslation.EntityNames.Application"); }
            }

            public static string Article
            {
                get { return TranslationAssistant.Translate("ApplicationCategories.SysTranslation.EntityNames.Article"); }
            }

            public static string Comment
            {
                get { return TranslationAssistant.Translate("ApplicationCategories.SysTranslation.EntityNames.Comment"); }
            }

            public static string ContentType
            {
                get { return TranslationAssistant.Translate("ApplicationCategories.SysTranslation.EntityNames.ContentType"); }
            }

            public static string ContentItem
            {
                get { return TranslationAssistant.Translate("ApplicationCategories.SysTranslation.EntityNames.ContentItem"); }
            }

            public static string ContentAttribute
            {
                get { return TranslationAssistant.Translate("ApplicationCategories.SysTranslation.EntityNames.ContentAttribute"); }
            }

            public static string ListValue
            {
                get { return TranslationAssistant.Translate("ApplicationCategories.SysTranslation.EntityNames.ListValue"); }
            }

            public static string Translation
            {
                get { return TranslationAssistant.Translate("ApplicationCategories.SysTranslation.EntityNames.Translation"); }
            }

            public static string Role
            {
                get { return TranslationAssistant.Translate("ApplicationCategories.SysTranslation.EntityNames.Role"); }
            }

            public static string User
            {
                get { return TranslationAssistant.Translate("ApplicationCategories.SysTranslation.EntityNames.User"); }
            }
        }

        public static class ContentItem
        {
            public static string InContentTypeXYZ(string xyz)
            {
                string formatXYZ = TranslationAssistant.Translate("ApplicationCategories.SysTranslation.ContentItem.InContentTypeXYZ");
                return string.Format(formatXYZ, xyz);
            }
        }
    }
}
