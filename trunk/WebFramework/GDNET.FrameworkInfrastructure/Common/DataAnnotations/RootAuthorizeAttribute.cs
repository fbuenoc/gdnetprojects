using System.Web;
using System.Web.Mvc;
using GDNET.Domain.Repositories;

namespace GDNET.FrameworkInfrastructure.Common.DataAnnotations
{
    public class RootAuthorizeAttribute : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (httpContext.User.Identity.IsAuthenticated)
            {
                var user = DomainRepositories.User.FindByEmail(httpContext.User.Identity.Name);
                return (user != null && user.IsActive && user.IsRoot);
            }

            return base.AuthorizeCore(httpContext);
        }
    }
}
