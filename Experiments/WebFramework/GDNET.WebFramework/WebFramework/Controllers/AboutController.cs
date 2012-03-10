using System.Web.Mvc;
using WebFramework.Base.Base;

namespace WebFramework.Controllers
{
    public class AboutController : AbstractController
    {
        public ActionResult Index()
        {
            return base.View();
        }
    }
}
