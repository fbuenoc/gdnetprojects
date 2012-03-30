using WebFramework.Domain;

namespace WebFramework.UI.Translations
{
    public class EntityTranslation
    {
        public string InContentTypeXYZ(string xyz)
        {
            string formatXYZ = DomainServices.Translation.Translate("SysTranslation.ContentItem.InContentTypeXYZ");
            return string.Format(formatXYZ, xyz);
        }
    }
}
