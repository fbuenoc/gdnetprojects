using System;

namespace GDNET.Domain.Base
{
    public interface IEntityWithModification : IEntity
    {
        DateTime CreatedAt { get; }
        DateTime? LastModifiedAt { get; }
        string CreatedBy { get; }
        string LastModifiedBy { get; }
    }
}
