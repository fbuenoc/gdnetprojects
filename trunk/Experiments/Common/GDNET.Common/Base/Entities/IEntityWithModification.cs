using System;

namespace GDNET.Common.Base.Entities
{
    /// <summary>
    /// Entity with creation/modificaion information
    /// </summary>
    public interface IEntityWithModification<TId> : IEntityWithActiveBase<TId>, IModification
    {
    }
}
