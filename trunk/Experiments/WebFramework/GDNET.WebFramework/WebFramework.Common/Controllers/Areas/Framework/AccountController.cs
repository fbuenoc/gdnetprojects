using System;
using System.Web.Mvc;
using GDNET.Web.Helpers;
using Telerik.Web.Mvc;
using WebFramework.Common.Constants;
using WebFramework.Common.Framework.AccountModeles;

namespace WebFramework.Common.Controllers.Areas.Framework
{
    public class AccountController : AbstractListCrudController<AccountModel>
    {
        #region ListCrudControllerBase members

        public override ActionResult List()
        {
            return base.View();
        }

        protected override AccountModel OnDetailsChecking(string id)
        {
            string providerUserKey;
            if (QueryStringAssistant.GetValueAsString(QueryStringConstants.Key, out providerUserKey))
            {
                return base.membershipService.GetUserByKey(new Guid(providerUserKey), false);
            }

            return default(AccountModel);
        }

        protected override object OnCreateExecuting(AccountModel model, FormCollection collection)
        {
            return null;
        }

        protected override AccountModel OnDeleteChecking(string id)
        {
            string providerUserKey;
            if (QueryStringAssistant.GetValueAsString(QueryStringConstants.Key, out providerUserKey))
            {
                return base.membershipService.GetUserByKey(new Guid(providerUserKey), false);
            }
            return default(AccountModel);
        }

        protected override bool OnDeleteExecuting(AccountModel model, FormCollection collection)
        {
            return base.membershipService.DeleteUser(model.UserName, true);
        }

        protected override bool OnEditExecuting(AccountModel model, FormCollection collection)
        {
            throw new NotImplementedException();
        }

        #endregion

        /// <summary>
        /// Get accounts support paging
        /// </summary>
        [GridAction(EnableCustomBinding = true)]
        public ActionResult TelerikGetAccounts(GridCommand command)
        {
            var paginatedAccounts = base.membershipService.GetList(command.Page - 1, command.PageSize);

            GridModel myGridModel = new GridModel
            {
                Data = paginatedAccounts,
                Total = base.membershipService.CountTotal()
            };

            return base.View(myGridModel);
        }

    }
}
