using GDNET.Domain.Base.Management;

namespace GDNET.Domain.Base
{
    public abstract class AbstractEntityWithModificationHistoryT<TId> : AbstractEntityT<TId>, IEntityWithModificationHistoryT<TId>
    {
        private EntityHistory entityHistory = null;

        public virtual EntityHistory EntityHistory
        {
            get { return entityHistory; }
        }

        public virtual void AssureCreationHistory()
        {
            if (this.entityHistory == null)
            {
                this.entityHistory = new EntityHistory();
            }
        }
    }
}
