using System;

namespace GDNET.Common.Base.Entities
{
    /// <summary>
    /// Entity with with Deletable, Editable, Creation/Modification info
    /// </summary>
    public abstract class EntityFullControlBase<TId> : EntityBase<TId>, IEntityDeletable<TId>, IEntityEditable<TId>, IEntityCreMod<TId>
    {
        #region IEntityDeletable Members

        public bool IsDeletable
        {
            get;
            set;
        }

        #endregion

        #region IEntityEditable Members

        public bool IsEditable
        {
            get;
            set;
        }

        #endregion

        #region IEntityCreMod Members

        public string CreatedBy
        {
            get;
            set;
        }

        public DateTime CreatedAt
        {
            get;
            set;
        }

        public string LastModifiedBy
        {
            get;
            set;
        }

        public DateTime? LastModifiedAt
        {
            get;
            set;
        }

        #endregion
    }
}
