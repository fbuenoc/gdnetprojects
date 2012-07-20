using GDNET.Domain.Base.Management;

namespace GDNET.Domain.Base
{
    public interface IEntityWithModificationHistory : IEntity
    {
        EntityLog FirstLog { get; }
        EntityLog LastLog { get; }
        void AddLogCreation();
        void AddLog(string message, string contentText);
    }
}
