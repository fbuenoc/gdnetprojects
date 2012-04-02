using System.Linq;
using System.Web.Mvc;
using GDNET.Web.Mvc.Helpers;
using WebFramework.Common.Controllers;
using WebFramework.Common.Framework.Common;
using WebFramework.Domain;
using WebFramework.Domain.Common;

namespace WebFramework.Areas.Framework.Controllers
{
    public class CultureController : AbstractListCrudController<CultureModel>
    {
        public override ActionResult List()
        {
            var listOfCultures = DomainRepositories.Culture.GetAll().Select(culture => new CultureModel(culture));
            return base.View(listOfCultures);
        }

        protected override object OnCreateExecuting(CultureModel model, FormCollection collection)
        {
            var culture = Culture.Factory.Create(model.CultureCode);
            var result = DomainRepositories.Culture.Save(culture);
            return result ? (object)culture.Id : null;
        }

        protected override bool OnDeleteExecuting(CultureModel model, FormCollection collection)
        {
            int entityId = collection.GetItemId<int>();
            return DomainRepositories.Culture.Delete(entityId);
        }

        protected override bool OnEditExecuting(CultureModel model, FormCollection collection)
        {
            try
            {
                var entity = DomainRepositories.Culture.GetById(model.Id);
                entity.IsDefault = model.IsDefault;

                return DomainRepositories.Culture.Update(entity);
            }
            catch
            {
                return false;
            }
        }
    }
}
