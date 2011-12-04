using System.Web.Mvc;
using System.Web.Routing;

using WebFramework.Models.AccountServices;

namespace WebFramework.Modeles.Base
{
    public abstract class MvcControllerBase : Controller
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
