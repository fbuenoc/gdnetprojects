using System.Web.Mvc;
using GDNET.WebFramework.Common;

namespace GDNET.WebFramework.Controllers
{
    public class HomeController : AbstractController
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to ASP.NET MVC!";

            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
