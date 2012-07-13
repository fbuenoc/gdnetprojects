using GDNET.Domain.Base.Management;

namespace GDNET.Domain.Base
{
    public abstract class AbstractEntityWithModificationHistoryT<TId> : AbstractEntityWithModificationT<TId>, IEntityWithModificationHistoryT<TId>
    {
        private EntityHistory history = default(EntityHistory);

        public virtual EntityHistory History
        {
            get { return history; }
        }
    }
}
