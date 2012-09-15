using System.ComponentModel.DataAnnotations;
using GDNET.FrameworkInfrastructure.Services;

namespace GDNET.FrameworkInfrastructure.Common.DataAnnotations
{
    public class StringLengthMLAttribute : StringLengthAttribute
    {
        public string ErrorKeyword
        {
            get;
            set;
        }

        public StringLengthMLAttribute(int maximumLength)
            : base(maximumLength)
        {
        }

        public StringLengthMLAttribute(int maximumLength, int minimumLength)
            : base(maximumLength)
        {
            base.MinimumLength = minimumLength;
        }

        public override bool IsValid(object value)
        {
            return base.IsValid(value);
        }

        public override string FormatErrorMessage(string name)
        {
            var format = WebFrameworkServices.Translation.GetByKeyword(this.ErrorKeyword);
            base.ErrorMessage = string.Format(format, name, base.MinimumLength, base.MaximumLength);
            return base.FormatErrorMessage(name);
        }
    }
}
