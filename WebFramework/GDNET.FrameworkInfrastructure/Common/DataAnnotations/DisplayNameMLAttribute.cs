using System.ComponentModel;
using GDNET.FrameworkInfrastructure.Services;

namespace GDNET.FrameworkInfrastructure.Common.DataAnnotations
{
    public class DisplayNameMLAttribute : DisplayNameAttribute
    {
        private string keyword;

        public DisplayNameMLAttribute(string keyword)
        {
            this.keyword = keyword;
        }

        public override string DisplayName
        {
            get
            {
                return WebFrameworkServices.Translation.GetByKeyword(keyword);
            }
        }
    }
}
