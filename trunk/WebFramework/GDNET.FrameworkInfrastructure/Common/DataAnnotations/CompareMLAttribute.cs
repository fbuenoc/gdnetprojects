using System.Web.Mvc;
using GDNET.FrameworkInfrastructure.Services;

namespace GDNET.FrameworkInfrastructure.Common.DataAnnotations
{
    public class CompareMLAttribute : CompareAttribute
    {
        public CompareMLAttribute(string otherProperty, string errorKeyword)
            : base(otherProperty)
        {
            base.ErrorMessage = WebFrameworkServices.Translation.GetByKeyword(errorKeyword);
        }
    }
}
