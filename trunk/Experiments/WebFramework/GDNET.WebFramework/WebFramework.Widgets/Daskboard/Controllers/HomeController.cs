using System.Web.Mvc;
using GDNET.Web.Helpers;
using WebFramework.Common.Constants;
using WebFramework.Common.Controllers;
using WebFramework.Common.Framework.System;
using WebFramework.Domain;
using WebFramework.Domain.System;
using WebFramework.Services.Common;
using WebFramework.Widgets.Daskboard.Helpers;

namespace WebFramework.Widgets.Daskboard.Controllers
{
    public class HomeController : AbstractController
    {
        public ActionResult Index()
        {
            string pageName = string.Empty;
            Page pageEntity = null;

            if (QueryStringAssistant.GetValueAsString(QueryStringConstants.Page, out pageName))
            {
                pageEntity = DomainRepositories.Page.GetByUniqueName(pageName);
            }
            else
            {
                pageEntity = DomainServices.Page.GetDefaultPage(WebSessionInformationService.Instance.CurrentApplication, WebSessionInformationService.Instance.CurrentCulture);
            }

            if (pageEntity == null)
            {
                return base.RedirectToAction("NoPage");
            }
            else
            {
                var pageModel = new PageModel(pageEntity);
                pageModel.AdministerUrl = DaskboardAssistant.GetPageAdministerUrl(pageEntity);

                return base.View(pageModel);
            }
        }

        public ActionResult NoPage()
        {
            return base.View();
        }

        public ActionResult OnError()
        {
            return base.View();
        }
    }
}
