using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Security;

using GDNET.Web.Mvc.Base;

namespace WebFramework.Modeles.Framework.AccountModeles
{
    public sealed class RoleModel : ModelBase
    {
        private List<string> usersInRole = new List<string>();

        /// <summary>
        /// The name of role
        /// </summary>
        [Required]
        [DisplayName("Role name")]
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        /// All users in this role
        /// </summary>
        public ReadOnlyCollection<string> Users
        {
            get { return new ReadOnlyCollection<string>(this.usersInRole); }
        }

        #region Ctors

        public RoleModel()
            : this(string.Empty)
        {
        }

        public RoleModel(string roleName)
            : base(roleName)
        {
            this.Name = roleName;
        }

        #endregion

        public void GetUsersInRole()
        {
            this.usersInRole.AddRange(Roles.GetUsersInRole(this.Name));
        }

        public bool DeleteRole()
        {
            var usersInRole = Roles.GetUsersInRole(this.Name);
            if (usersInRole.Length > 0)
            {
                Roles.RemoveUsersFromRole(usersInRole, this.Name);
            }

            return Roles.DeleteRole(this.Name, true);
        }
    }
}
