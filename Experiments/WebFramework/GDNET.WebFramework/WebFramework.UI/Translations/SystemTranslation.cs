using WebFramework.Domain;

namespace WebFramework.UI.Translations
{
    public class SystemTranslation
    {
        #region Common translations

        public string Attributes
        {
            get { return DomainServices.Translation.Translate("SysTranslation.Attributes"); }
        }

        public string Category
        {
            get { return DomainServices.Translation.Translate("SysTranslation.Category"); }
        }

        public string CreatedAt
        {
            get { return DomainServices.Translation.Translate("SysTranslation.CreatedAt"); }
        }

        public string CreatedBy
        {
            get { return DomainServices.Translation.Translate("SysTranslation.CreatedBy"); }
        }

        public string DeleteAndContinue
        {
            get { return DomainServices.Translation.Translate("SysTranslation.DeleteAndContinue"); }
        }

        public string DeleteConfirmation
        {
            get { return DomainServices.Translation.Translate("SysTranslation.DeleteConfirmation"); }
        }

        public string DeleteConfirmationXYZ(string xyz)
        {
            string confirmationXYZ = DomainServices.Translation.Translate("SysTranslation.DeleteConfirmationXYZ");
            return string.Format(confirmationXYZ, xyz);
        }

        public string DetailOfXYZ(string xyz)
        {
            string detailXYZ = DomainServices.Translation.Translate("SysTranslation.DetailOfXYZ");
            return string.Format(detailXYZ, xyz);
        }

        public string Name
        {
            get { return DomainServices.Translation.Translate("SysTranslation.Name"); }
        }

        public string Code
        {
            get { return DomainServices.Translation.Translate("SysTranslation.Code"); }
        }

        public string Description
        {
            get { return DomainServices.Translation.Translate("SysTranslation.Description"); }
        }

        public string ReturnToListOfXYZ(string xyz)
        {
            string returnToXYZ = DomainServices.Translation.Translate("SysTranslation.ReturnToListOfXYZ");
            return string.Format(returnToXYZ, xyz);
        }

        public string SaveAndContinue
        {
            get { return DomainServices.Translation.Translate("SysTranslation.SaveAndContinue"); }
        }

        public string Statut
        {
            get { return DomainServices.Translation.Translate("SysTranslation.Statut"); }
        }

        #endregion

        #region Entities name translations

        public string EntityApplication
        {
            get { return DomainServices.Translation.Translate("SysTranslation.EntityNames.Application"); }
        }

        public string EntityArticle
        {
            get { return DomainServices.Translation.Translate("SysTranslation.EntityNames.Article"); }
        }

        public string EntityComment
        {
            get { return DomainServices.Translation.Translate("SysTranslation.EntityNames.Comment"); }
        }

        public string EntityContentType
        {
            get { return DomainServices.Translation.Translate("SysTranslation.EntityNames.ContentType"); }
        }

        public string EntityContentItem
        {
            get { return DomainServices.Translation.Translate("SysTranslation.EntityNames.ContentItem"); }
        }

        public string EntityContentAttribute
        {
            get { return DomainServices.Translation.Translate("SysTranslation.EntityNames.ContentAttribute"); }
        }

        public string EntityCulture
        {
            get { return DomainServices.Translation.Translate("SysTranslation.EntityNames.Culture"); }
        }

        public string EntityListValue
        {
            get { return DomainServices.Translation.Translate("SysTranslation.EntityNames.ListValue"); }
        }

        public string EntityTranslation
        {
            get { return DomainServices.Translation.Translate("SysTranslation.EntityNames.Translation"); }
        }

        public string EntityRole
        {
            get { return DomainServices.Translation.Translate("SysTranslation.EntityNames.Role"); }
        }

        public string EntityUser
        {
            get { return DomainServices.Translation.Translate("SysTranslation.EntityNames.User"); }
        }

        public string EntityPage
        {
            get { return DomainServices.Translation.Translate("SysTranslation.EntityNames.Page"); }
        }

        public string EntityWidget
        {
            get { return DomainServices.Translation.Translate("SysTranslation.EntityNames.Widget"); }
        }

        public string EntityZone
        {
            get { return DomainServices.Translation.Translate("SysTranslation.EntityNames.Zone"); }
        }

        #endregion


    }
}
