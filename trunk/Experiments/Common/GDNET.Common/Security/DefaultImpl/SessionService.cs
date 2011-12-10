using System.Security.Principal;

using GDNET.Common.Security.Services;

namespace GDNET.Common.Security.DefaultImpl
{
    public abstract class SessionService : ISessionService
    {
        public static SessionService Instance
        {
            get;
            protected set;
        }

        public SessionService(SessionService instance)
        {
            Instance = instance;
        }

        #region ISessionService Members

        public IPrincipal User
        {
            get;
            protected set;
        }

        public bool IsAuthenticated
        {
            get;
            protected set;
        }

        #endregion

    }
}
