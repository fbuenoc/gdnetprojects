using System.Linq;
using System.Web.Mvc;

using WebFrameworkDomain.Common;
using WebFrameworkDomain.DefaultImpl;

using WebFramework.Modeles.Base;
using WebFramework.Modeles.Framework.DomainModels;

namespace WebFramework.Areas.Framework.Controllers
{
    public class ApplicationController : ListCrudControllerBase<ApplicationModel>
    {
        #region ListCrudControllerBase Members

        public override ActionResult List()
        {
            var listOfApplications = DomainRepositories.Application.GetAll().Select(app => new ApplicationModel(app));
            return base.View(listOfApplications);
        }

        public override ActionResult Details(string id)
        {
            ApplicationModel modele = this.GetById(id);
            if (modele != default(ApplicationModel))
            {
                return base.View(modele);
            }

            return base.RedirectToAction(ActionList);
        }

        public override ActionResult Create()
        {
            ApplicationModel modele = new ApplicationModel();
            return base.View(ViewCreateOrUpdate, modele);
        }

        public override ActionResult Create(ApplicationModel model, FormCollection collection)
        {
            var application = Application.Factory.Create(model.RootUrl, model.Name, model.Description);
            var result = DomainRepositories.Application.Save(application);

            if (result)
            {
                return base.RedirectToAction(ActionDetails, new { id = application.Id.ToString() });
            }
            else
            {
                return base.View(ViewCreateOrUpdate, model);
            }
        }

        public override ActionResult Delete(string id)
        {
            ApplicationModel modele = this.GetById(id);
            if (modele != default(ApplicationModel))
            {
                return base.View(modele);
            }

            return base.RedirectToAction(ActionList);
        }

        public override ActionResult Delete(ApplicationModel model, FormCollection collection)
        {
            bool result = DomainRepositories.Application.Delete(model.Id);
            if (result)
            {
                return base.RedirectToAction(ActionList);
            }

            return base.View(model);
        }

        public override ActionResult Edit(string id)
        {
            return base.View(ViewCreateOrUpdate);
        }

        public override ActionResult Edit(ApplicationModel model, FormCollection collection)
        {
            return base.View(ViewCreateOrUpdate);
        }

        #endregion

        /// <summary>
        /// Get application model
        /// </summary>
        private ApplicationModel GetById(string id)
        {
            int applicationId;
            ApplicationModel applicationModele = null;

            if (int.TryParse(id, out applicationId))
            {
                var appEntity = DomainRepositories.Application.GetById(applicationId);
                applicationModele = new ApplicationModel(appEntity);
            }

            return applicationModele;
        }
    }
}
