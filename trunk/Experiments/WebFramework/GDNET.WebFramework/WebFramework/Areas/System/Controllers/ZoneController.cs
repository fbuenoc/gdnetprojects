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

        protected override ZoneModel OnDetailsChecking(string id)
        {
            return base.GetModelById(id);
        }

        protected override object OnCreateExecuting(ZoneModel model, FormCollection collection)
        {
            throw new NotImplementedException();
        }

        protected override ZoneModel OnDeleteChecking(string id)
        {
            return base.GetModelById(id);
        }

        protected override bool OnDeleteExecuting(ZoneModel model, FormCollection collection)
        {
            throw new NotImplementedException();
        }

        protected override ZoneModel OnEditChecking(string id)
        {
            return base.GetModelById(id);
        }

        protected override bool OnEditExecuting(ZoneModel model, FormCollection collection)
        {
            try
            {
                var entity = DomainRepositories.Zone.GetById(model.Id);
                entity.Code = model.Code;
                entity.Description = model.Description;

                return DomainRepositories.Zone.Update(entity);
            }
            catch
            {
                return false;
            }
        }
    }
}
