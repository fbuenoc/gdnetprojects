using System;

namespace GDNET.Domain.Base
{
    public interface IEntityWithModification : IEntityWithCreation
    {
        DateTime? LastModifiedAt { get; }
        string LastModifiedBy { get; }
    }
}
