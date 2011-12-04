using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

using GDNET.Web.Helpers;

using WebFramework.Constants;
using WebFramework.Modeles.Base;
using WebFramework.Modeles.Framework.AccountModeles;

namespace WebFramework.Areas.Framework.Controllers
{
    public class RoleController : ListCrudControllerBase<RoleModel>
    {
        public const string ActionAddUser = "AddUser";

        #region ListCrudControllerBase members

        public override ActionResult List()
        {
            List<RoleModel> listOfRoles = new List<RoleModel>();
            listOfRoles.AddRange(Roles.GetAllRoles().Select(role => new RoleModel(role)));

            return base.View(listOfRoles);
        }

        public override ActionResult Details()
        {
            string roleName;
            QueryStringHelper.GetValueAsString(QueryStringConstants.Role, out roleName);

            RoleModel roleModel = new RoleModel(roleName);
            roleModel.GetUsersInRole();

            return base.View(roleModel);
        }

        public override ActionResult Create()
        {
            RoleModel model = new RoleModel();
            return base.View(ViewCreateOrUpdate, model);
        }

        [HttpPost]
        public override ActionResult Create(RoleModel model, FormCollection collection)
        {
            try
            {
                Roles.CreateRole(model.Name);
                return base.RedirectToAction(ActionList);
            }
            catch
            {
                return base.View(ViewCreateOrUpdate, model);
            }
        }

        public override ActionResult Delete()
        {
            // Get name of role from query string
            string roleName;
            QueryStringHelper.GetValueAsString(QueryStringConstants.Role, out roleName);

            RoleModel model = new RoleModel(roleName);

            return base.View(model);
        }

        [HttpPost]
        public override ActionResult Delete(RoleModel model, FormCollection collection)
        {
            try
            {
                model.DeleteRole();
                return base.RedirectToAction(ActionList);
            }
            catch
            {
                return base.View(model);
            }
        }

        public override ActionResult Edit(string id)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public override ActionResult Edit(RoleModel model, FormCollection collection)
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
            QueryStringHelper.GetValueAsString(QueryStringConstants.Role, out roleName);

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
