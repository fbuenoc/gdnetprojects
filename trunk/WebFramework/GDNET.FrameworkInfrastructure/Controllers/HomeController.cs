﻿using System.Web.Mvc;
using GDNET.Domain.Content;
using GDNET.Domain.Repositories;
using GDNET.FrameworkInfrastructure.Common;
using GDNET.FrameworkInfrastructure.Common.Base;
using GDNET.FrameworkInfrastructure.Common.Extensions;
using GDNET.FrameworkInfrastructure.Models.Content;
using GDNET.FrameworkInfrastructure.Services;

namespace GDNET.FrameworkInfrastructure.Controllers
{
    public class HomeController : AbstractController
    {
        private const int DefaultPageSize = 10;

        public ActionResult Index()
        {
            var listContentItems = DomainRepositories.ContentItem.GetTopActive(DefaultPageSize);
            var listItems = FrameworkExtensions.ConvertAll<ContentItemModel, ContentItem>(listContentItems);

            return base.View(listItems);
        }

        public ActionResult Details(string id)
        {
            ContentItemModel contentModel = WebFrameworkServices.ContentModels.GetContentItemModel(id);
            if (contentModel == null)
            {
                return base.RedirectToAction(ControllerAssistant.GetActionName(() => this.Index()));
            }

            return base.View(contentModel);
        }

        public ActionResult About()
        {
            return base.View();
        }
    }
}
