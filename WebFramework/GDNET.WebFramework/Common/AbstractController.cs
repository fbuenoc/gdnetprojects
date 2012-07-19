using System.Web.Mvc;
using System.Web.Routing;

namespace GDNET.WebFramework.Common
{
    public class AbstractController : Controller
    {
        protected override void Initialize(RequestContext requestContext)
        {
            base.Initialize(requestContext);
        }
    }
}