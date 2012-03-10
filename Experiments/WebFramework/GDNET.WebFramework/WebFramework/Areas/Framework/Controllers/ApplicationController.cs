using System.Linq;
using System.Web.Mvc;
using GDNET.Web.Mvc.Helpers;
using WebFramework.Base.Base;
using WebFramework.Base.Framework.Common;
using WebFramework.Domain.Common;
using WebFramework.Domain.DefaultImpl;

namespace WebFramework.Areas.Framework.Controllers
{
    public class ApplicationController : AbstractListCrudController<ApplicationModel>
    {
        #region ListCrudControllerBase Members

        public override ActionResult List()
        {
            var listOfApplications = DomainRepositories.Application.GetAll().Select(app => new ApplicationModel(app));
            return base.View(listOfApplications);
        }

        protected override ApplicationModel OnDetailsChecking(string id)
        {
            return base.GetModelById(id);
        }

        protected override object OnCreateExecuting(ApplicationModel model, FormCollection collection)
        {
            var application = Application.Factory.Create(model.Name, model.Description, model.RootUrl);
            var result = DomainRepositories.Application.Save(application);
            return result ? (object)application.Id : null;
        }

        protected override ApplicationModel OnDeleteChecking(string id)
        {
            return base.GetModelById(id);
        }

        protected override bool OnDeleteExecuting(ApplicationModel model, FormCollection collection)
        {
            long appId = collection.GetItemId<long>();
            return DomainRepositories.Application.Delete(appId);
        }

        protected override ApplicationModel OnEditChecking(string id)
        {
            return base.GetModelById(id);
        }

        protected override bool OnEditExecuting(ApplicationModel model, FormCollection collection)
        {
            try
            {
                var appEntity = DomainRepositories.Application.GetById(model.Id);
                if (appEntity.Description != null)
                {
                    appEntity.Description.Value = model.Description;
                }
                appEntity.RootUrl = model.RootUrl;
                if (appEntity.Name != null)
                {
                    appEntity.Name.Value = model.Name;
                }

                return DomainRepositories.Application.Update(appEntity);
            }
            catch
            {
                return false;
            }
        }

        #endregion
    }
}
