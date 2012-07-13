using System.Security.Principal;

namespace GDNET.Domain.Base.SessionManagement
{
    public abstract class DomainSessionContext : ISessionContext
    {
        private static DomainSessionContext instance = default(DomainSessionContext);

        public static DomainSessionContext Instance
        {
            get { return instance; }
        }

        public abstract IIdentity CurrentUser { get; }
    }
}
