using GDNET.Domain.Base.Management;

namespace GDNET.Domain.Base
{
    public abstract class AbstractEntityWithModificationHistoryT<TId> : AbstractEntityT<TId>, IEntityWithModificationHistoryT<TId>
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

        public virtual void AddLogCreation()
        {
            this.AddLog("Creation", string.Empty);
        }

        public abstract void AddLog(string message, string contentText);
    }
}
