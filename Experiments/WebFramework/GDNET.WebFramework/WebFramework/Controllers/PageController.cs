using System.Web.Mvc;
using GDNET.Web.Helpers;
using WebFramework.Base.Framework.System;
using WebFramework.Common.Controllers;
using WebFramework.Domain;

namespace WebFramework.Controllers
{
    public class PageController : AbstractController
    {
        public ActionResult Index()
        {
            var pageUniqueName = QueryStringAssistant.GetValueAsString("page");
            var pageObject = DomainRepositories.Page.GetByUniqueName(pageUniqueName);
            if (pageObject != null)
            {
                var pageModel = new PageModel(pageObject);
                return base.View(pageModel);
            }

            return base.View();
        }
    }
}
