using System.Web.Mvc;
using GDNET.Web.Helpers;
using WebFramework.Common.Constants;
using WebFramework.Common.Controllers;
using WebFramework.Common.Framework.System;
using WebFramework.Domain;
using WebFramework.Services.Common;

namespace WebFramework.Widgets.Daskboard.Controllers
{
    public class HomeController : AbstractController
    {
        public ActionResult Index()
        {
            var defaultPage = DomainServices.Page.GetDefaultPage(WebSessionInformationService.Instance.CurrentApplication, WebSessionInformationService.Instance.CurrentCulture);
            if (defaultPage == null)
            {
                return base.RedirectToAction("NoPage");
            }
            else
            {
                var pageModel = new PageModel(defaultPage);
                return base.View(pageModel);
            }
        }

        public ActionResult Page()
        {
            var pageUniqueName = QueryStringAssistant.GetValueAsString(QueryStringConstants.Page);
            var pageEntity = DomainRepositories.Page.GetByUniqueName(pageUniqueName);
            if (pageEntity != null)
            {
                var pageModel = new PageModel(pageEntity);
                return base.View(pageModel);
            }

            return base.View();
        }
    }
}
