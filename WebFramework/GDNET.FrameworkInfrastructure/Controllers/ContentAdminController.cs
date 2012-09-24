﻿using System;
using System.Web.Mvc;
using GDNET.Domain.Content;
using GDNET.Domain.Repositories;
using GDNET.FrameworkInfrastructure.Common.Base;
using GDNET.FrameworkInfrastructure.Common.DataAnnotations;
using GDNET.FrameworkInfrastructure.Common.Extensions;
using GDNET.FrameworkInfrastructure.Controllers.Base;
using GDNET.FrameworkInfrastructure.Models.Content;
using GDNET.FrameworkInfrastructure.Services;

namespace GDNET.FrameworkInfrastructure.Controllers
{
    [RootAuthorize]
    public class ContentAdminController : AbstractListController
    {
        public override ActionResult List()
        {
            var listItems = DomainRepositories.ContentItem.GetAll();
            var listeModels = FrameworkExtensions.ConvertAll<ContentItemModel, ContentItem>(listItems);

            return base.View(listeModels);
        }

        public ActionResult Details(string id)
        {
            ContentItemModel contentModel = WebFrameworkServices.ContentModels.GetContentItemModel(id);
            if (contentModel == null)
            {
                return base.RedirectToAction(ControllerAssistant.GetActionName(() => this.List()));
            }

            return base.View(contentModel);
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

        #region Part methods

        public ActionResult MoveUpPart(string id, string cid)
        {
            var contentItem = DomainRepositories.ContentItem.GetById(new Guid(cid));
            if (contentItem != null)
            {
                contentItem.MoveUpPartById(new Guid(id));
                return base.RedirectToAction(ControllerAssistant.GetActionName(() => this.Details(cid)), new { id = cid });
            }
            else
            {
                return base.RedirectToAction(ControllerAssistant.GetActionName(() => this.List()));
            }
        }

        public ActionResult MoveDownPart(string id, string cid)
        {
            var contentItem = DomainRepositories.ContentItem.GetById(new Guid(cid));
            if (contentItem != null)
            {
                contentItem.MoveDownPartById(new Guid(id));
                return base.RedirectToAction(ControllerAssistant.GetActionName(() => this.Details(cid)), new { id = cid });
            }
            else
            {
                return base.RedirectToAction(ControllerAssistant.GetActionName(() => this.List()));
            }
        }

        public ActionResult DeletePart(string id, string cid)
        {
            var contentItem = DomainRepositories.ContentItem.GetById(new Guid(cid));
            if (contentItem != null)
            {
                contentItem.RemovePartById(new Guid(id));
                return base.RedirectToAction(ControllerAssistant.GetActionName(() => this.Details(cid)), new { id = cid });
            }
            else
            {
                return base.RedirectToAction(ControllerAssistant.GetActionName(() => this.List()));
            }
        }

        public ActionResult EditPart(string id, string cid)
        {
            ContentPartModel partModel = WebFrameworkServices.ContentModels.GetContentPartModel(id, cid);
            if (partModel == null)
            {
                return base.RedirectToAction(ControllerAssistant.GetActionName(() => this.Details(cid)), new { id = cid });
            }
            else
            {
                partModel.Mode = ViewModelMode.Modification;
            }

            return base.View("CreateOrUpdatePart", partModel);
        }

        [HttpPost]
        public ActionResult EditPart(string id, string cid, ContentPartModel partModel, FormCollection collection)
        {
            if (base.ModelState.IsValid)
            {
                var contentPart = WebFrameworkServices.ContentModels.GetContentPart(id, cid);
                if (contentPart != null)
                {
                    WebFrameworkServices.ContentModels.UpdateContentPart(contentPart, partModel);
                    return base.RedirectToAction(ControllerAssistant.GetActionName(() => this.Details(cid)), new { id = cid });
                }
            }

            return base.View("CreateOrUpdatePart", partModel);
        }

        public ActionResult CreatePart(string id)
        {
            ContentPartModel partModel = new ContentPartModel()
            {
                IsActive = true,
                Mode = ViewModelMode.Creation
            };

            return base.View("CreateOrUpdatePart", partModel);
        }

        [HttpPost]
        public ActionResult CreatePart(string id, ContentPartModel partModel, FormCollection collection)
        {
            if (base.ModelState.IsValid)
            {
                var contentItem = DomainRepositories.ContentItem.GetById(new Guid(id));
                if (contentItem != null)
                {
                    var partItem = WebFrameworkServices.ContentModels.CreateContentPart(partModel);
                    contentItem.AddPart(partItem);

                    return base.RedirectToAction(ControllerAssistant.GetActionName(() => this.Details(id)), ControllerAssistant.BuildRouteValues(id));
                }
            }

            return base.View("CreateOrUpdatePart", partModel);
        }

        #endregion

        #region Create methods

        public ActionResult Create()
        {
            ContentItemModel itemModel = new ContentItemModel()
            {
                IsActive = true,
                Mode = ViewModelMode.Creation
            };

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
                    string id = contentItem.Id.ToString();
                    return base.RedirectToAction(ControllerAssistant.GetActionName(() => this.Details(id)), ControllerAssistant.BuildRouteValues(id));
                }
            }

            return base.View("CreateOrUpdate", itemModel);
        }

        #endregion

        #region Edit methods

        public ActionResult Edit(string id)
        {
            ContentItemModel contentModel = WebFrameworkServices.ContentModels.GetContentItemModel(id);
            if (contentModel == null)
            {
                return base.RedirectToAction(ControllerAssistant.GetActionName(() => this.List()));
            }

            return base.View("CreateOrUpdate", contentModel);
        }

        [HttpPost]
        public ActionResult Edit(string id, ContentItemModel contentModel, FormCollection collection)
        {
            if (base.ModelState.IsValid)
            {
                var contentItem = DomainRepositories.ContentItem.GetById(new Guid(id));
                if (contentItem != null)
                {
                    WebFrameworkServices.ContentModels.UpdateContentItem(contentItem, contentModel);
                    return base.RedirectToAction(ControllerAssistant.GetActionName(() => this.Details(id)), new { id = id });
                }
            }

            return base.View("CreateOrUpdate", contentModel);
        }

        #endregion

        #region Delete methods

        public ActionResult Delete(string id)
        {
            DomainRepositories.ContentItem.Delete(new Guid(id));
            return base.RedirectToAction(ControllerAssistant.GetActionName(() => this.List()));
        }

        #endregion
    }
}