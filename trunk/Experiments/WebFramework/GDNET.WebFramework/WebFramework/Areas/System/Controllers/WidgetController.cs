using System;
using System.Linq;
using System.Web.Mvc;
using WebFramework.Common.Controllers;
using WebFramework.Common.Framework.System;
using WebFramework.Domain;

namespace WebFramework.Areas.System.Controllers
{
    public class WidgetController : AbstractListCrudController<WidgetModel>
    {
        public override ActionResult List()
        {
            var listeEntites = DomainRepositories.Widget.GetAll().Select(entity => new WidgetModel(entity));
            return base.View(listeEntites);
        }

        protected override object OnCreateExecuting(WidgetModel model, FormCollection collection)
        {
            throw new NotImplementedException();
        }

        protected override bool OnDeleteExecuting(WidgetModel model, FormCollection collection)
        {
            throw new NotImplementedException();
        }

        protected override bool OnEditExecuting(WidgetModel model, FormCollection collection)
        {
            var entity = DomainRepositories.Widget.GetById(model.Id);
            entity.Name.Value = model.Name;
            entity.Description.Value = model.Description;

            return DomainRepositories.Widget.Update(entity);
        }
    }
}
