using System;

namespace GDNET.Domain.Base
{
    public interface IEntityWithCreation : IEntity
    {
        DateTime CreatedAt { get; }
        string CreatedBy { get; }
    }
}
