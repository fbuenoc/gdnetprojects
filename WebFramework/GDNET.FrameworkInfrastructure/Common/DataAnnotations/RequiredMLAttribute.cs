using System.ComponentModel.DataAnnotations;
using GDNET.FrameworkInfrastructure.Services;

namespace GDNET.FrameworkInfrastructure.Common.DataAnnotations
{
    public class RequiredMLAttribute : System.ComponentModel.DataAnnotations.RequiredAttribute
    {
        private string displayName;

        public RequiredMLAttribute(string keyword)
        {
            base.ErrorMessageResourceName = keyword;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            this.displayName = validationContext.DisplayName;
            return base.IsValid(value, validationContext);
        }

        public override string FormatErrorMessage(string name)
        {
            var message = WebFrameworkServices.Translation.GetByKeyword(base.ErrorMessageResourceName);
            return string.Format(message, this.displayName);
        }
    }
}
