using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Telerik.Web.Mvc;

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

        public override ActionResult Details()
        {
            return base.View();
        }

        public override ActionResult Create()
        {
            return base.View();
        }

        public override ActionResult Create(AccountModel model, FormCollection collection)
        {
            return base.View();
        }

        public override ActionResult Delete()
        {
            return base.View();
        }

        public override ActionResult Delete(AccountModel model, FormCollection collection)
        {
            return base.View();
        }

        public override ActionResult Edit(string id)
        {
            return base.View();
        }

        public override ActionResult Edit(AccountModel model, FormCollection collection)
        {
            return base.View();
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
