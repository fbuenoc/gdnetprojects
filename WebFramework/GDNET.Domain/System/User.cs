using GDNET.Domain.Base.Management;

namespace GDNET.Domain.System
{
    public partial class User : EntityHistory
    {
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

        public virtual bool IsActive
        {
            get;
            set;
        }

        internal protected User() { }
    }
}
