using System;

namespace GDNET.Domain.Base
{
    public abstract class AbstractEntityWithModificationT<TId> : AbstractEntityT<TId>, IEntityWithModificationT<TId>
    {
        private DateTime createdAt;
        private DateTime lastModifiedAt;
        private string createdBy;
        private string lastModifiedBy;

        public virtual DateTime CreatedAt
        {
            get { return createdAt; }
        }

        public virtual DateTime LastModifiedAt
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
