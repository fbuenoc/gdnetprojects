using System;
using System.Linq;
using System.Web.Mvc;
using WebFramework.Common.Controllers;
using WebFramework.Common.Framework.System;
using WebFramework.Domain;

namespace WebFramework.Areas.System.Controllers
{
    public class ZoneController : AbstractListCrudController<ZoneModel>
    {
        public override ActionResult List()
        {
            var listeEntites = DomainRepositories.Zone.GetAll().Select(entity => new ZoneModel(entity));
            return base.View(listeEntites);
        }

        protected override object OnCreateExecuting(ZoneModel model, FormCollection collection)
        {
            throw new NotImplementedException();
        }

        protected override bool OnDeleteExecuting(ZoneModel model, FormCollection collection)
        {
            throw new NotImplementedException();
        }

        protected override bool OnEditExecuting(ZoneModel model, FormCollection collection)
        {
            var entity = DomainRepositories.Zone.GetById(model.Id);
            entity.Code = model.Code;
            entity.Description = model.Description;

            return DomainRepositories.Zone.Update(entity);
        }
    }
}
