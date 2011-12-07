using System;
using System.Web.Mvc;
using System.Web.Routing;

using GDNET.Common.DesignByContract;
using GDNET.Web.Membership.DefaultImpl;
using GDNET.Web.Membership.Services;

using WebFramework.Models.AccountServices;
using WebFramework.Modeles.Framework.Common;
using WebFramework.Modeles.Framework.DomainModels;

using WebFrameworkDomain.DefaultImpl;

namespace WebFramework.Modeles.Base
{
    public abstract class MvcControllerBase<TModel> : MvcControllerBase
    {
        protected TModel GetModelById(string id)
        {
            return ModelService.GetModelById<TModel>(id);
        }
    }

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
