using System.Web.Mvc;
using System.Web.Routing;

namespace GDNET.FrameworkInfrastructure.Controllers.Base
{
    public abstract class AbstractController : Controller
    {
        protected override void Initialize(RequestContext requestContext)
        {
            base.Initialize(requestContext);
        }
    }
}