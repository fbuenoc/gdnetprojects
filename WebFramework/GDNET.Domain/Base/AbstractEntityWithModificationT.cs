using System;
using GDNET.Domain.Base.SessionManagement;

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

        public virtual void InitializeModificationInfos()
        {
            if (string.IsNullOrEmpty(this.CreatedBy) && base.Id.Equals(default(TId)))
            {
                this.createdAt = DateTime.Now;
                this.createdBy = DomainSessionContext.Instance.CurrentUser.Email;
            }
            else
            {
                this.lastModifiedAt = DateTime.Now;
                this.lastModifiedBy = DomainSessionContext.Instance.CurrentUser.Email;
            }
        }
    }
}
