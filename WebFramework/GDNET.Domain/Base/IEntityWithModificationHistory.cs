using GDNET.Domain.Base.Management;

namespace GDNET.Domain.Base
{
    public interface IEntityWithModificationHistory : IEntityWithModification
    {
        EntityLog FirstLog { get; }
        EntityLog LastLog { get; }
        bool IsActive { get; set; }

        void AddLogCreation();
        void AddLog(string message, string contentText);
    }
}
