using System;
using System.Web.Mvc;
using GDNET.Domain.Content;
using GDNET.Domain.Repositories;
using GDNET.FrameworkInfrastructure.Common;
using GDNET.FrameworkInfrastructure.Models.Content;
using GDNET.FrameworkInfrastructure.Services;

namespace GDNET.FrameworkInfrastructure.Controllers
{
    [Authorize]
    public class ContentAdminController : AbstractController
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Details(int id)
        {
            return base.View();
        }

        public ActionResult ManageParts(string id)
        {
            ContentItem contentItem = DomainRepositories.ContentItem.GetById(new Guid(id));
            if (contentItem != null)
            {
                var model = WebFrameworkServices.ContentModels.GetContentItemParts(contentItem);
                return base.View(model);
            }

            return base.RedirectToAction(ControllerAssistant.GetActionName(() => this.Index()));
        }

        public ActionResult CreatePart(string id)
        {
            ContentPartModel partModel = new ContentPartModel() { };
            return base.View("CreateOrUpdatePart", partModel);
        }

        [HttpPost]
        public ActionResult CreatePart(string id, ContentPartModel partModel, FormCollection collection)
        {
            if (base.ModelState.IsValid)
            {
                var contentItem = DomainRepositories.ContentItem.GetById(new Guid(id));
                var partItem = WebFrameworkServices.ContentModels.CreateContentPart(partModel);
                contentItem.AddPart(partItem);

                DomainRepositories.RepositoryManager.Flush();
                return base.RedirectToAction(ControllerAssistant.GetActionName(() => this.ManageParts(id)), ControllerAssistant.BuildRouteValues(id));
            }

            return base.View("CreateOrUpdatePart", partModel);
        }

        public ActionResult Create()
        {
            ContentItemModel itemModel = new ContentItemModel() { };
            return base.View("CreateOrUpdate", itemModel);
        }

        [HttpPost]
        public ActionResult Create(ContentItemModel itemModel, FormCollection collection)
        {
            if (base.ModelState.IsValid)
            {
                var contentItem = WebFrameworkServices.ContentModels.CreateContentItem(itemModel);
                bool result = DomainRepositories.ContentItem.Save(contentItem);
                if (result)
                {
                    return base.RedirectToAction(ControllerAssistant.GetActionName(() => this.ManageParts(contentItem.Id.ToString())), ControllerAssistant.BuildRouteValues(contentItem.Id.ToString()));
                }
            }

            return base.View("CreateOrUpdate", itemModel);
        }

        public ActionResult Edit(int id)
        {
            return base.View();
        }

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                return RedirectToAction("Index");
            }
            catch
            {
                return base.View();
            }
        }

        public ActionResult Delete(int id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
