using System.Web.Mvc;
using WebFramework.Modeles.Base;

namespace WebFramework.Areas.Framework.Controllers
{
    public class HomeController : MvcControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }

    }
}
