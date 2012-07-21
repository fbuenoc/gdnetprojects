using GDNET.Domain.Base.Management;

namespace GDNET.Domain.Base
{
    public abstract class AbstractEntityWithModificationHistoryT<TId> : AbstractEntityWithModificationT<TId>, IEntityWithModificationHistoryT<TId>
    {
        public virtual EntityLog FirstLog
        {
            get;
            protected internal set;
        }

        public virtual EntityLog LastLog
        {
            get;
            protected internal set;
        }

        public virtual bool IsActive
        {
            get;
            set;
        }

        public virtual void AddLogCreation()
        {
            this.AddLog("Creation", string.Empty);
        }

        public abstract void AddLog(string message, string contentText);
    }
}
