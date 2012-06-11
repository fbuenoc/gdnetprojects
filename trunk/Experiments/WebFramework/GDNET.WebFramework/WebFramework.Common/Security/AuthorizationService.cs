using System;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using FluentSecurity;
using GDNET.Web.Mvc.Services;

namespace WebFramework.Common.Security
{
    public class AuthorizationService : IAuthorizationService
    {
        public bool ActionIsAllowedForUser(string controllerName, string actionName)
        {
            var configuration = SecurityConfiguration.Current;
            var policyContainer = configuration.PolicyContainers.GetContainerFor(controllerName, actionName);

            if (policyContainer != null)
            {
                var context = SecurityContext.Current;
                var results = policyContainer.EnforcePolicies(context);
                return results.All(x => x.ViolationOccured == false);
            }

            return true;
        }

        public bool ActionIsAllowedForUser(string controllerName, params string[] actionsName)
        {
            foreach (string actionName in actionsName)
            {
                if (!this.ActionIsAllowedForUser(controllerName, actionName))
                {
                    return false;
                }
            }

            return true;
        }

        public bool IsAllowForUser<TController>(Expression<Func<TController, object>> actionExpression) where TController : Controller
        {
            var controllerName = typeof(TController).GetControllerName();
            var actionName = actionExpression.GetActionName();
            return this.ActionIsAllowedForUser(controllerName, actionName);
        }

        public bool CanManageWidget(string entityInfo)
        {
            if (!string.IsNullOrEmpty(entityInfo))
            {
                if (this.ActionIsAllowedForUser("WebFramework.Controllers.MonitorController", "Region"))
                {
                    return true;
                }
            }

            return false;
        }

        public bool CanManagePage(string entityInfo)
        {
            if (!string.IsNullOrEmpty(entityInfo))
            {
                if (this.ActionIsAllowedForUser("WebFramework.Controllers.MonitorController", "Page"))
                {
                    return true;
                }
            }

            return false;
        }

        public bool IsAllowedForUserOnData(string entityInfo)
        {
            if (!string.IsNullOrEmpty(entityInfo))
            {
                var userIdentity = HttpContext.Current.User.Identity;
                if (userIdentity != null && !string.IsNullOrEmpty(userIdentity.Name))
                {
                    return true;
                }
            }

            return false;
        }

        public bool UserIsAuthenticated()
        {
            return (HttpContext.Current.User.Identity != null) && HttpContext.Current.User.Identity.IsAuthenticated;
        }
    }
}