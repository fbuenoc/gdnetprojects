using System.Security.Principal;

namespace GDNET.Common.Security
{
    public interface ISessionService
    {
        IPrincipal User
        {
            get;
        }

        bool IsAuthenticated
        {
            get;
        }
    }
}
