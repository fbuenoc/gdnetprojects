using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Security;

using GDNET.Web.Membership.Profiles.Objects;
using GDNET.Web.Mvc.Base;
using GDNET.Web.Membership.Profiles;

namespace WebFramework.Modeles.Framework.AccountModeles
{
    public sealed class AccountModel : ModelBase
    {
        /// <summary>
        /// User key
        /// </summary>
        public string ProviderUserKey
        {
            get { return this.User.ProviderUserKey.ToString(); }
        }

        /// <summary>
        /// User name
        /// </summary>
        public string UserName
        {
            get { return this.User.UserName; }
        }

        /// <summary>
        /// Email
        /// </summary>
        public string Email
        {
            get { return this.User.Email; }
        }

        /// <summary>
        /// Creation date
        /// </summary>
        public DateTime CreationDate
        {
            get { return this.User.CreationDate; }
        }

        /// <summary>
        /// Last login date
        /// </summary>
        public DateTime LastLoginDate
        {
            get { return this.User.LastLoginDate; }
        }

        /// <summary>
        /// User profile information
        /// </summary>
        public CommonInformation BasicInformation
        {
            get
            {
                CustomProfile profile = new CustomProfile();
                profile.Initialize(this.UserName, true);
                return profile.BasicInformation;
            }
        }

        public MembershipUser User
        {
            get;
            private set;
        }

        public AccountModel(MembershipUser user)
            : base(user.ProviderUserKey.ToString())
        {
            this.User = user;
        }
    }
}
