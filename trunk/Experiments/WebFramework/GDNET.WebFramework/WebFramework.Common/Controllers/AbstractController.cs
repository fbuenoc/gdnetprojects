using System.Web.Mvc;
using System.Web.Routing;
using GDNET.Web.Membership.DefaultImpl;
using GDNET.Web.Membership.Services;
using GDNET.Web.Mvc.Helpers;
using WebFramework.Common.AccountServices;
using WebFramework.Domain;
using WebFramework.Domain.System;

namespace WebFramework.Common.Controllers
{
    public abstract class AbstractController : Controller
    {
        protected IFormsAuthenticationService formsService = null;
        protected IMembershipService membershipService = null;
        private Widget currentWidget = null;

        public const string ActionIndex = "Index";

        protected override void Initialize(RequestContext requestContext)
        {
            this.formsService = new FormsAuthenticationService();
            this.membershipService = new AccountMembershipService();

            base.Initialize(requestContext);
        }

        protected Widget CurrentWidget
        {
            get
            {
                if (this.currentWidget == null)
                {
                    string technicalName = this.GetAreaName();
                    this.currentWidget = DomainRepositories.Widget.GetByTechnicalName(technicalName);
                }
                return this.currentWidget;
            }
        }
    }
}
