using System.Web.Mvc;
using System.Web.Routing;
using GDNET.Web.Membership.DefaultImpl;
using GDNET.Web.Membership.Services;
using WebFramework.Common.AccountServices;

namespace WebFramework.Common.Controllers
{
    public abstract class AbstractController : Controller
    {
        protected IFormsAuthenticationService formsService = null;
        protected IMembershipService membershipService = null;

        protected override void Initialize(RequestContext requestContext)
        {
            this.formsService = new FormsAuthenticationService();
            this.membershipService = new AccountMembershipService();

            base.Initialize(requestContext);
        }
    }
}
