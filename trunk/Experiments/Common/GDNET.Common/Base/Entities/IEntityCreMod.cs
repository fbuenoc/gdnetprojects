using System;

namespace GDNET.Common.Base.Entities
{
    /// <summary>
    /// Entity with creation/modificaion information
    /// </summary>
    public interface IEntityCreMod<TId> : IEntity<TId>
    {
        /// <summary>
        /// Created by email
        /// </summary>
        string CreatedBy
        {
            get;
            set;
        }

        DateTime CreatedAt
        {
            get;
            set;
        }

        /// <summary>
        /// Last modified by email
        /// </summary>
        string LastModifiedBy
        {
            get;
            set;
        }

        DateTime? LastModifiedAt
        {
            get;
            set;
        }
    }
}
