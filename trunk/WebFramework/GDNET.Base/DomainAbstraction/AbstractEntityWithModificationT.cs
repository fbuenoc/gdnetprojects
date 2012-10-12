using System;

namespace GDNET.Base.DomainAbstraction
{
    public abstract class AbstractEntityWithModificationT<TId> : AbstractEntityT<TId>, IEntityWithModificationT<TId>
    {
        private DateTime createdAt = DateTime.MinValue;
        private DateTime? lastModifiedAt = null;
        private string createdBy = string.Empty;
        private string lastModifiedBy = string.Empty;

        public virtual DateTime CreatedAt
        {
            get { return createdAt; }
        }

        public virtual DateTime? LastModifiedAt
        {
            get { return lastModifiedAt; }
        }

        public virtual string CreatedBy
        {
            get { return createdBy; }
        }

        public virtual string LastModifiedBy
        {
            get { return lastModifiedBy; }
        }
    }
}
