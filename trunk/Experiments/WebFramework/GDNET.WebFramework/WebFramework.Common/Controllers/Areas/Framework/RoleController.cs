﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using GDNET.Web.Helpers;
using WebFramework.Common.Constants;
using WebFramework.Common.Framework.AccountModeles;
using WebFramework.Common.Security;

namespace WebFramework.Common.Controllers.Areas.Framework
{
    public class RoleController : AbstractListCrudController<RoleModel>, IRequiredAdministratorController
    {
        public const string ActionAddUser = "AddUser";

        #region ListCrudControllerBase members

        public override ActionResult List()
        {
            List<RoleModel> listOfRoles = new List<RoleModel>();
            listOfRoles.AddRange(Roles.GetAllRoles().Select(role => new RoleModel(role)));

            return base.View(listOfRoles);
        }

        protected override RoleModel OnDetailsChecking(string id)
        {
            string roleName;
            if (QueryStringAssistant.GetValueAsString(QueryStringConstants.Role, out roleName))
            {
                RoleModel roleModel = new RoleModel(roleName);
                return roleModel.GetUsersInRole();
            }

            return default(RoleModel);
        }

        protected override object OnCreateExecuting(RoleModel model, FormCollection collection)
        {
            Roles.CreateRole(model.Name);
            return model.Name;
        }

        protected override RoleModel OnDeleteChecking(string id)
        {
            // Get name of role from query string
            string roleName;
            if (QueryStringAssistant.GetValueAsString(QueryStringConstants.Role, out roleName))
            {
                RoleModel model = new RoleModel(roleName);
            }
            return default(RoleModel);
        }

        protected override bool OnDeleteExecuting(RoleModel model, FormCollection collection)
        {
            return model.DeleteRole();
        }

        protected override RoleModel OnEditChecking(string id)
        {
            // Get name of role from query string
            string roleName;
            if (QueryStringAssistant.GetValueAsString(QueryStringConstants.Role, out roleName))
            {
                RoleModel model = new RoleModel(roleName);
            }
            return default(RoleModel);
        }

        protected override bool OnEditExecuting(RoleModel model, FormCollection collection)
        {
            throw new NotImplementedException();
        }

        #endregion

        /// <summary>
        /// Displays a form to add user
        /// </summary>
        public ActionResult AddUser()
        {
            // Get name of role from query string
            string roleName = string.Empty;
            QueryStringAssistant.GetValueAsString(QueryStringConstants.Role, out roleName);

            AccountRoleModel model = new AccountRoleModel();
            model.RoleName = roleName;

            return base.View(model);
        }

        /// <summary>
        /// Add an user to role
        /// </summary>
        [HttpPost]
        public ActionResult AddUser(AccountRoleModel model, FormCollection collection)
        {
            try
            {
                Roles.AddUserToRole(model.UserName, model.RoleName);
                return base.RedirectToAction("Details", new { role = model.RoleName });
            }
            catch
            {
                return base.View(model);
            }
        }

    }
}
