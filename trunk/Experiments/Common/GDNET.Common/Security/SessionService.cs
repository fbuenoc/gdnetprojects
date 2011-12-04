using System.Security.Principal;

namespace GDNET.Common.Security
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
