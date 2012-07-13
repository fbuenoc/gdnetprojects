using System.Security.Principal;

namespace GDNET.Domain.Base.SessionManagement
{
    public interface ISessionContext
    {
        IIdentity CurrentUser { get; }
    }
}
