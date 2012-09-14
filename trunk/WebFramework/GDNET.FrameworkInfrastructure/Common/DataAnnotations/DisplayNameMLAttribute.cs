using System.ComponentModel;
using GDNET.FrameworkInfrastructure.Services;

namespace GDNET.FrameworkInfrastructure.Common.DataAnnotations
{
    public class DisplayNameMLAttribute : DisplayNameAttribute
    {
        public DisplayNameMLAttribute(string keyword)
        {
            base.DisplayNameValue = WebFrameworkServices.Translation.GetByKeyword(keyword);
        }
    }
}
