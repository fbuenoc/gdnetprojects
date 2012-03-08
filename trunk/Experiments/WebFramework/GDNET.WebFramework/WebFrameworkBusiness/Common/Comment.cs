using GDNET.Common.Security.Services;
using GDNET.Common.Types;
using WebFrameworkBusiness.Base;

namespace WebFrameworkBusiness.Common
{
    public sealed partial class Comment : BusinessEntityBase, IBusinessEntity
    {
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
