﻿using System.Web.Mvc;
using GDNET.FrameworkInfrastructure.Controllers.Extensions;

namespace GDNET.FrameworkInfrastructure.Controllers.Base
{
    public abstract class AbstractListController : AbstractController
    {
        public ActionResult Index()
        {
            return base.RedirectToAction(ControllerAssistant.GetActionName(() => this.List()));
        }

        public abstract ActionResult List();
    }
}