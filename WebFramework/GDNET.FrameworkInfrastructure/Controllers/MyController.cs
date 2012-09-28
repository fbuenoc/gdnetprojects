using System.Web.Mvc;
using GDNET.FrameworkInfrastructure.Controllers.Base;

namespace GDNET.FrameworkInfrastructure.Controllers
{
    public class MyController : AbstractController
    {
        public ActionResult ChangeLanguage()
        {
            return base.View();
        }
    }
}
