using GDNET.Common.Base.Entities;
using WebFrameworkDomain.Common;

namespace WebFrameworkDomain.Extensions
{
    public static class EntityExtensions
    {
        public static void RefreshTranslation(this IEntitySignature entity, Translation translation, string propertyName)
        {
            if ((entity != null) && (translation != null))
            {
                translation.Code = string.Format("{0}_{1}", entity.Signature, propertyName);
            }
        }
    }
}
