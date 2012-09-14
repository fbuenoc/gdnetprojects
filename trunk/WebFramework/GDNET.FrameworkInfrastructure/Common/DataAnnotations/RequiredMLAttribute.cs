using System.ComponentModel.DataAnnotations;
using GDNET.FrameworkInfrastructure.Services;

namespace GDNET.FrameworkInfrastructure.Common.DataAnnotations
{
    public class RequiredMLAttribute : RequiredAttribute
    {
        public RequiredMLAttribute(string keyword)
            : base()
        {
            base.ErrorMessage = WebFrameworkServices.Translation.GetByKeyword(keyword);
        }
    }
}
