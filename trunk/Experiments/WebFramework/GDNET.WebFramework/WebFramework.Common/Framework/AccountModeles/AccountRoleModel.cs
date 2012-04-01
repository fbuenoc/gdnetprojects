using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

using GDNET.Common.Base.Entities;

namespace WebFramework.Common.Framework.AccountModeles
{
    public sealed class AccountRoleModel : EntityWithActive<string>
    {
        /// <summary>
        /// The name of role
        /// </summary>
        [Required]
        [DisplayName("Role name")]
        public string RoleName
        {
            get;
            set;
        }

        [Required]
        [DisplayName("User name")]
        public string UserName
        {
            get;
            set;
        }

        #region Ctors

        public AccountRoleModel()
            : base()
        {
            base.Id = Guid.NewGuid().ToString();
        }

        #endregion

    }
}
