using WebFramework.Domain;

namespace WebFramework.Extensions
{
    public static class Translations
    {
        public static class System
        {
            public static string Attributes
            {
                get { return DomainServices.Translation.Translate("SysTranslation.Attributes"); }
            }

            public static string Category
            {
                get { return DomainServices.Translation.Translate("SysTranslation.Category"); }
            }

            public static string CreatedAt
            {
                get { return DomainServices.Translation.Translate("SysTranslation.CreatedAt"); }
            }

            public static string CreatedBy
            {
                get { return DomainServices.Translation.Translate("SysTranslation.CreatedBy"); }
            }

            public static string DeleteAndContinue
            {
                get { return DomainServices.Translation.Translate("SysTranslation.DeleteAndContinue"); }
            }

            public static string DeleteConfirmation
            {
                get { return DomainServices.Translation.Translate("SysTranslation.DeleteConfirmation"); }
            }

            public static string DeleteConfirmationXYZ(string xyz)
            {
                string confirmationXYZ = DomainServices.Translation.Translate("SysTranslation.DeleteConfirmationXYZ");
                return string.Format(confirmationXYZ, xyz);
            }

            public static string DetailOfXYZ(string xyz)
            {
                string detailXYZ = DomainServices.Translation.Translate("SysTranslation.DetailOfXYZ");
                return string.Format(detailXYZ, xyz);
            }

            public static string Name
            {
                get { return DomainServices.Translation.Translate("SysTranslation.Name"); }
            }

            public static string Description
            {
                get { return DomainServices.Translation.Translate("SysTranslation.Description"); }
            }

            public static string ReturnToListOfXYZ(string xyz)
            {
                string returnToXYZ = DomainServices.Translation.Translate("SysTranslation.ReturnToListOfXYZ");
                return string.Format(returnToXYZ, xyz);
            }

            public static string SaveAndContinue
            {
                get { return DomainServices.Translation.Translate("SysTranslation.SaveAndContinue"); }
            }

            public static string Statut
            {
                get { return DomainServices.Translation.Translate("SysTranslation.Statut"); }
            }
        }

        public static class EntityNames
        {
            public static string Application
            {
                get { return DomainServices.Translation.Translate("SysTranslation.EntityNames.Application"); }
            }

            public static string Article
            {
                get { return DomainServices.Translation.Translate("SysTranslation.EntityNames.Article"); }
            }

            public static string Comment
            {
                get { return DomainServices.Translation.Translate("SysTranslation.EntityNames.Comment"); }
            }

            public static string ContentType
            {
                get { return DomainServices.Translation.Translate("SysTranslation.EntityNames.ContentType"); }
            }

            public static string ContentItem
            {
                get { return DomainServices.Translation.Translate("SysTranslation.EntityNames.ContentItem"); }
            }

            public static string ContentAttribute
            {
                get { return DomainServices.Translation.Translate("SysTranslation.EntityNames.ContentAttribute"); }
            }

            public static string ListValue
            {
                get { return DomainServices.Translation.Translate("SysTranslation.EntityNames.ListValue"); }
            }

            public static string Translation
            {
                get { return DomainServices.Translation.Translate("SysTranslation.EntityNames.Translation"); }
            }

            public static string Role
            {
                get { return DomainServices.Translation.Translate("SysTranslation.EntityNames.Role"); }
            }

            public static string User
            {
                get { return DomainServices.Translation.Translate("SysTranslation.EntityNames.User"); }
            }
        }

        public static class ContentItem
        {
            public static string InContentTypeXYZ(string xyz)
            {
                string formatXYZ = DomainServices.Translation.Translate("SysTranslation.ContentItem.InContentTypeXYZ");
                return string.Format(formatXYZ, xyz);
            }
        }
    }
}
