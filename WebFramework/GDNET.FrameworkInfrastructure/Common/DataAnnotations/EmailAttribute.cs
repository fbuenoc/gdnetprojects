using System.ComponentModel.DataAnnotations;
using GDNET.FrameworkInfrastructure.Services;

namespace GDNET.FrameworkInfrastructure.Common.DataAnnotations
{
    public sealed class EmailAttribute : RegularExpressionAttribute
    {
        private static readonly string EmailPattern = @"^[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+(?:[A-Z]{2}|com|org|net|edu|gov|mil|biz|info|mobi|name|aero|asia|jobs|museum)$";

        public string ErrorKeyword
        {
            get;
            set;
        }

        public EmailAttribute()
            : base(EmailPattern)
        {
        }

        public override string FormatErrorMessage(string name)
        {
            var format = WebFrameworkServices.Translation.GetByKeyword(this.ErrorKeyword);
            return string.Format(format, name);
        }
    }
}
