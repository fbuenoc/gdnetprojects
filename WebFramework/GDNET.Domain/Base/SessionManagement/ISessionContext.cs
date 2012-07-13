using GDNET.Domain.System;

namespace GDNET.Domain.Base.SessionManagement
{
    public interface ISessionContext
    {
        User CurrentUser { get; }
    }
}
