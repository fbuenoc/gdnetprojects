using GDNET.Common.Security.Services;
using GDNET.Common.Types;
using WebFrameworkBusiness.Base;

namespace WebFrameworkBusiness.Common
{
    public sealed partial class Comment : BusinessEntityBase
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

        public Contact FullName
        {
            get { return base.GetValue<Contact>(() => this.FullName); }
            set { base.SetValue(() => this.FullName, value); }
        }

        public Email Email
        {
            get { return base.GetValue<Email>(() => this.Email); }
            set { base.SetValue(() => this.Email, value); }
        }

        protected Comment()
            : this(EncryptionOption.None)
        {
        }

        protected Comment(EncryptionOption encryption)
            : base(encryption)
        {
        }
    }
}
