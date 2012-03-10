using System.Text;
using GDNET.Extensions;
using WebFramework.Common.Services;
using WebFramework.Business.Common;
using WebFramework.Domain.Common;

namespace WebFramework.Common.DefaultImpl
{
    public class NavigationService : INavigationService
    {
        public string GetUrlDetails(ContentItem contentItem)
        {
            StringBuilder urlBuilder = new StringBuilder();
            string typeName = contentItem.ContentType.TypeName;

            if (typeName == typeof(Product).GetQualifiedTypeName())
            {
                urlBuilder.AppendFormat("~/Product/Details/{0}", contentItem.Id);
            }
            else
            {
                urlBuilder.AppendFormat("~/Item/Details/{0}", contentItem.Id);
            }

            return urlBuilder.ToString();
        }
    }
}