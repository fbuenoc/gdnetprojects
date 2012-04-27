using System.Web.Mvc;

namespace WebFramework.Common.Controllers
{
    [Authorize]
    public abstract class AbstractAuthorizeController : AbstractController
    {
    }
}
