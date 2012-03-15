using System.Web.Mvc;
using WebFramework.Common.Controllers;

namespace WebFramework.Controllers
{
    public class AboutController : AbstractController
    {
        public ActionResult Index()
        {
            return base.View();
        }

        public ActionResult Contact()
        {
            return base.View();
        }
    }
}
