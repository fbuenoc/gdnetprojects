using System;
using System.Web.Mvc;
using GDNET.Web.Helpers;
using Telerik.Web.Mvc;
using WebFramework.Constants;
using WebFramework.Modeles.Base;
using WebFramework.Modeles.Framework.AccountModeles;

namespace WebFramework.Areas.Framework.Controllers
{
    public class AccountController : ListCrudControllerBase<AccountModel>
    {
        #region ListCrudControllerBase members

        /// <summary>
        /// GET: /Framework/Account/List/
        /// </summary>
        /// <returns></returns>
        public override ActionResult List()
        {
            return base.View();
        }

        protected override AccountModel OnDetailsChecking(string id)
        {
            string providerUserKey;
            if (QueryStringHelper.GetValueAsString(QueryStringConstants.Key, out providerUserKey))
            {
                return base.membershipService.GetUserByKey(new Guid(providerUserKey), false);
            }

            return default(AccountModel);
        }

        protected override object OnCreateExecuting(AccountModel model, FormCollection collection)
        {
            throw new NotImplementedException();
        }

        protected override AccountModel OnDeleteChecking(string id)
        {
            string providerUserKey;
            if (QueryStringHelper.GetValueAsString(QueryStringConstants.Key, out providerUserKey))
            {
                return base.membershipService.GetUserByKey(new Guid(providerUserKey), false);
            }
            return default(AccountModel);
        }

        protected override bool OnDeleteExecuting(AccountModel model, FormCollection collection)
        {
            return base.membershipService.DeleteUser(model.UserName, true);
        }

        protected override AccountModel OnEditChecking(string id)
        {
            return base.GetModelById(id);
        }

        protected override bool OnEditExecuting(AccountModel model, FormCollection collection)
        {
            throw new NotImplementedException();
        }

        #endregion

        /// <summary>
        /// Get accounts support paging
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
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
