using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

using GDNET.Web.Mvc.Base;

namespace WebFramework.Modeles.Framework.AccountModeles
{
    public sealed class AccountRoleModel : ModelBase
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
            : base(true)
        {
        }

        #endregion

    }
}
