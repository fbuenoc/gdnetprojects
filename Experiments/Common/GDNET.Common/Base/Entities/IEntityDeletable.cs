﻿namespace GDNET.Common.Base.Entities
{
    /// <summary>
    /// Entity with IsDeletable property
    /// </summary>
    public interface IEntityDeletable<TId> : IEntityActiveBase<TId>
    {
        bool IsDeletable
        {
            get;
            set;
        }
    }
}