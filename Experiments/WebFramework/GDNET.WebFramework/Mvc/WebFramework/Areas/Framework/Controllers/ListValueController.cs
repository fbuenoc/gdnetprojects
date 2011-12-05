using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using WebFramework.Modeles.Base;
using WebFramework.Modeles.Framework.DomainModels;
using WebFrameworkDomain.DefaultImpl;

namespace WebFramework.Areas.Framework.Controllers
{
    public class ListValueController : ListCrudControllerBase<ListValueModel>
    {
        #region ListCrudControllerBase Members

        public override ActionResult List()
        {
            var rootValues = DomainRepositories.ListValue.GetAllRootValues().Select(lv => new ListValueModel(lv));
            return base.View(rootValues);
        }

        public override ActionResult Details(string id)
        {
            var lvModel = this.GetById(id);
            if (lvModel == default(ListValueModel))
            {
                return base.RedirectToAction(ActionList);
            }

            return base.View(lvModel);
        }

        public override ActionResult Create()
        {
            throw new NotImplementedException();
        }

        public override ActionResult Create(ListValueModel model, FormCollection collection)
        {
            throw new NotImplementedException();
        }

        public override ActionResult Delete(string id)
        {
            throw new NotImplementedException();
        }

        public override ActionResult Delete(ListValueModel model, FormCollection collection)
        {
            throw new NotImplementedException();
        }

        public override ActionResult Edit(string id)
        {
            throw new NotImplementedException();
        }

        public override ActionResult Edit(ListValueModel model, FormCollection collection)
        {
            throw new NotImplementedException();
        }

        #endregion

        private ListValueModel GetById(string id)
        {
            int lvId;
            if (int.TryParse(id, out lvId))
            {
                var lvEntity = DomainRepositories.ListValue.GetById(lvId);
                return new ListValueModel(lvEntity);
            }

            return default(ListValueModel);
        }
    }
}
