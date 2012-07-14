using GDNET.Domain.Base.Management;

namespace GDNET.Domain.Base
{
    public abstract class AbstractEntityWithModificationHistoryT<TId> : AbstractEntityWithModificationT<TId>, IEntityWithModificationHistoryT<TId>
    {
        private EntityHistory history = null;

        public virtual EntityHistory History
        {
            get { return history; }
        }

        public virtual void AssureCreationHistory()
        {
            if (this.history == null)
            {
                this.history = new EntityHistory();
            }
        }
    }
}
