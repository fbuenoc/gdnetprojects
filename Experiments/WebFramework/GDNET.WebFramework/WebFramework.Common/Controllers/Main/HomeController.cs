using System.Web.Mvc;
using WebFramework.Common.Controllers;
using WebFramework.Domain;
using WebFramework.Services.Common;

namespace WebFramework.Controllers.Main
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
                return base.RedirectToAction("Index", "Page", new { page = defaultPage.UniqueName });
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
