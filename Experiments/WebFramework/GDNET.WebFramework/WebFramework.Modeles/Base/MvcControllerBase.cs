using System;
using System.Web.Mvc;
using System.Web.Routing;

using GDNET.Common.DesignByContract;
using GDNET.Web.Membership.DefaultImpl;
using GDNET.Web.Membership.Services;

using WebFramework.Models.AccountServices;
using WebFramework.Modeles.Framework.DomainModels;

using WebFrameworkDomain.DefaultImpl;

namespace WebFramework.Modeles.Base
{
    public abstract class MvcControllerBase<TModel> : MvcControllerBase
    {
        protected TModel GetModelById(string id)
        {
            long modelId;

            if (long.TryParse(id, out modelId))
            {
                if (typeof(TModel).FullName == typeof(ApplicationModel).FullName)
                {
                    var app = DomainRepositories.Application.GetById(modelId);
                    if (app != null)
                    {
                        return (TModel)Convert.ChangeType(new ApplicationModel(app), typeof(TModel));
                    }
                }
                else if (typeof(TModel).FullName == typeof(ListValueModel).FullName)
                {
                    var lv = DomainRepositories.ListValue.GetById(modelId);
                    if (lv != null)
                    {
                        return (TModel)Convert.ChangeType(new ListValueModel(lv), typeof(TModel));
                    }
                }
                else
                {
                    Throw.NotImplementedException(string.Format("Not implemented for type: '{0}'", typeof(TModel).FullName));
                }
            }

            return default(TModel);
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
