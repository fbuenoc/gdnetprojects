using System.Linq;
using System.Web.Mvc;

using WebFramework.Modeles.Base;
using WebFramework.Modeles.Framework.DomainModels;

using WebFrameworkDomain.Common;
using WebFrameworkDomain.DefaultImpl;

namespace WebFramework.Areas.Framework.Controllers
{
    public class ContentTypeController : ListCrudControllerBase<ContentTypeModel>
    {
        public override ActionResult List()
        {
            var listOfContentTypes = DomainRepositories.ContentType.GetAll().Select(type => new ContentTypeModel(type));
            return base.View(listOfContentTypes);
        }

        protected override object OnCreateExecuting(ContentTypeModel model, FormCollection collection)
        {
            var ctEntity = ContentType.Factory.Create(model.Name, model.TypeName);
            bool result = DomainRepositories.ContentType.Save(ctEntity);
            return result ? (object)ctEntity.Id : null;
        }

        protected override ContentTypeModel OnDetailsChecking(string id)
        {
            return base.GetModelById(id);
        }

        protected override ContentTypeModel OnDeleteChecking(string id)
        {
            return base.GetModelById(id);
        }

        protected override bool OnDeleteExecuting(ContentTypeModel model, FormCollection collection)
        {
            return DomainRepositories.ContentType.Delete(model.Id);
        }

        protected override ContentTypeModel OnEditChecking(string id)
        {
            return base.GetModelById(id);
        }

        protected override bool OnEditExecuting(ContentTypeModel model, FormCollection collection)
        {
            try
            {
                var ctEntity = DomainRepositories.ContentType.GetById(model.Id);
                if (ctEntity.Name != null)
                {
                    ctEntity.Name.Value = model.Name;
                }
                ctEntity.TypeName = model.TypeName;

                return DomainRepositories.ContentType.Save(ctEntity);
            }
            catch
            {
                return false;
            }
        }
    }
}
