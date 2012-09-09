using System.Web.Mvc;

namespace GDNET.FrameworkInfrastructure.Common
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