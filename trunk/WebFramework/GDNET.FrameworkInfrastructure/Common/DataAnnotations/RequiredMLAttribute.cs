using System.ComponentModel.DataAnnotations;
using GDNET.FrameworkInfrastructure.Services;

namespace GDNET.FrameworkInfrastructure.Common.DataAnnotations
{
    /// <summary>
    /// Doesn't work : JS validation is not worked
    /// </summary>
    public class RequiredMLAttribute : RequiredAttribute
    {
        public RequiredMLAttribute(string keyword)
            : base()
        {
            base.AllowEmptyStrings = false;
            base.ErrorMessage = WebFrameworkServices.Translation.GetByKeyword(keyword);
        }
    }
}
