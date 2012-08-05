using GDNET.Domain.Base.Management;
using GDNET.Domain.Services;

namespace GDNET.Domain.Entities.System
{
    public partial class User : EntityHistoryComplex
    {
        #region Properties

        public virtual string Email
        {
            get;
            protected set;
        }

        public virtual string DisplayName
        {
            get;
            set;
        }

        public virtual string Password
        {
            get;
            protected set;
        }

        public virtual Employee Employee
        {
            get;
            set;
        }

        #endregion

        #region Methods

        public virtual bool ChangePassword(string oldPassword, string newPassword)
        {
            bool result = false;
            if (this.Password == DomainServices.Encryption.Encrypt(oldPassword))
            {
                this.Password = DomainServices.Encryption.Encrypt(newPassword);
                result = true;
            }

            return result;
        }

        #endregion

        internal protected User() { }
    }
}
