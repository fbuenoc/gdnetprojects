using System;
using GDNET.Domain.Base.Management;

namespace GDNET.Domain.Base
{
    public interface IEntityWithModificationHistory : IEntityWithModification
    {
        EntityLog FirstLog { get; }
        EntityLog LastLog { get; }

        bool IsActive { get; set; }
        Int64 Views { get; set; }

        void AddLogCreation();
        void AddLog(string message, string contentText);
    }
}
