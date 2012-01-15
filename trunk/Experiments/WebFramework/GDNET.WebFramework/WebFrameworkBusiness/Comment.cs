using GDNET.Common.Security.Services;
using WebFrameworkBusiness.Base;

namespace WebFrameworkBusiness
{
    public sealed class Comment : BusinessItemBase
    {
        public string Title
        {
            get { return base.GetValue<string>(() => this.Title); }
            set { base.SetValue(() => this.Title, value); }
        }

        public string Body
        {
            get { return base.GetValue<string>(() => this.Body); }
            set { base.SetValue(() => this.Body, value); }
        }

        public string FullName
        {
            get { return base.GetValue<string>(() => this.FullName); }
            set { base.SetValue(() => this.FullName, value); }
        }

        public string Email
        {
            get { return base.GetValue<string>(() => this.Email); }
            set { base.SetValue(() => this.Email, value); }
        }

        public Comment()
            : this(EncryptionOption.None)
        {
        }

        public Comment(EncryptionOption encryption)
            : base(encryption)
        {
        }
    }
}
