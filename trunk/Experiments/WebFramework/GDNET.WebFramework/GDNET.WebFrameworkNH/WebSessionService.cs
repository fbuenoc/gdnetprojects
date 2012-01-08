using System.Web;

using GDNET.Common.Security;
using GDNET.Common.Security.DefaultImpl;

namespace WebFrameworkNHibernate
{
    public class WebSessionService : SessionService
    {
        private static readonly WebSessionService _instance = new WebSessionService();

        public WebSessionService()
            : base(_instance)
        {
            base.User = (HttpContext.Current.User == null) ? new FakePrincipal() : HttpContext.Current.User;
            base.IsAuthenticated = (HttpContext.Current.User != null);
        }
    }
}
