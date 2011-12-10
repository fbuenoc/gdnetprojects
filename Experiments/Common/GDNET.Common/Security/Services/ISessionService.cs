using System.Security.Principal;

namespace GDNET.Common.Security.Services
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
