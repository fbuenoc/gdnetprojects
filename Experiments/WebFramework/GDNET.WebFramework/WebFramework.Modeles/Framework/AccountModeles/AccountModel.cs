using System;
using System.Web.Security;

using GDNET.Common.Base.Entities;

using GDNET.Web.Membership.Profiles;
using GDNET.Web.Membership.Profiles.Objects;

namespace WebFramework.Models.Framework.AccountModeles
{
    public sealed class AccountModel : EntityBase<string>
    {
        /// <summary>
        /// User key
        /// </summary>
        public string ProviderUserKey
        {
            get { return base.Id; }
        }

        /// <summary>
        /// User name
        /// </summary>
        public string UserName
        {
            get;
            set;
        }

        /// <summary>
        /// Email
        /// </summary>
        public string Email
        {
            get { return (this.User == null) ? string.Empty : this.User.Email; }
        }

        /// <summary>
        /// Creation date
        /// </summary>
        public DateTime CreationDate
        {
            get { return (this.User == null) ? default(DateTime) : this.User.CreationDate; }
        }

        /// <summary>
        /// Last login date
        /// </summary>
        public DateTime LastLoginDate
        {
            get { return (this.User == null) ? default(DateTime) : this.User.LastLoginDate; }
        }

        /// <summary>
        /// User profile information
        /// </summary>
        public CommonInformation BasicInformation
        {
            get
            {
                CustomProfile profile = new CustomProfile();
                if (!string.IsNullOrEmpty(this.UserName))
                {
                    profile.Initialize(this.UserName, true);
                }

                return profile.BasicInformation;
            }
        }

        public MembershipUser User
        {
            get;
            private set;
        }

        #region Ctors

        public AccountModel()
            : base()
        {
        }

        public AccountModel(MembershipUser user)
            : base()
        {
            this.User = user;
            this.UserName = user.UserName;
            this.Id = user.ProviderUserKey.ToString();
        }

        #endregion
    }
}
