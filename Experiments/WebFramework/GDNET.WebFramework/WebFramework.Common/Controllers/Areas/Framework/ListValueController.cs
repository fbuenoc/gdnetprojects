using System.Linq;
using System.Web.Mvc;
using GDNET.Web.Helpers;
using WebFramework.Common.Constants;
using WebFramework.Common.Framework.Common;
using WebFramework.Domain;
using WebFramework.Domain.Common;

namespace WebFramework.Common.Controllers.Areas.Framework
{
    public class ListValueController : AbstractListCrudController<ListValueModel>
    {
        #region ListCrudControllerBase Members

        public override ActionResult List()
        {
            var rootValues = DomainRepositories.ListValue.GetAllRootValues().Select(lv => new ListValueModel(lv));
            return base.View(rootValues);
        }

        protected override ListValueModel OnCreateChecking()
        {
            string parentId;
            var model = new ListValueModel();
            if (QueryStringAssistant.GetValueAs<string>(QueryStringConstants.Key, out parentId))
            {
                var parentModel = base.GetModelById(parentId);
                model.UpdateParent(parentModel);
            }

            return model;
        }

        protected override object OnCreateExecuting(ListValueModel model, FormCollection collection)
        {
            var listValue = ListValue.Factory.Create(model.Name, model.Description, model.CustomValue, model.ParentId);
            bool result = DomainRepositories.ListValue.Save(listValue);
            return result ? (object)listValue.Id : null;
        }

        protected override bool OnDeleteExecuting(ListValueModel model, FormCollection collection)
        {
            return DomainRepositories.ListValue.Delete(model.Id);
        }

        protected override bool OnEditExecuting(ListValueModel model, FormCollection collection)
        {
            try
            {
                var lvEntity = DomainRepositories.ListValue.GetById(model.Id);
                lvEntity.CustomValue = model.CustomValue;
                if (lvEntity.Description != null)
                {
                    lvEntity.Description.Value = model.Description;
                }
                lvEntity.Position = model.Position;

                return DomainRepositories.ListValue.Update(lvEntity);
            }
            catch
            {
                return false;
            }
        }

        #endregion
    }
}
