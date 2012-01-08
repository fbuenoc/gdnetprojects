using System;

using NHibernate.Event;
using NHibernate.Event.Default;
using NHibernate.Persister.Entity;

namespace GDNET.NHibernateImpl.Listeners
{
    public abstract class NhSaveEventListenerBase : DefaultSaveEventListener
    {
        protected override object PerformSave(object entity, object id, IEntityPersister persister, bool useIdentityColumn, object anything, IEventSource source, bool requiresImmediateIdAccess)
        {
            this.PerformSaving(entity);

            object obj = base.PerformSave(entity, id, persister, useIdentityColumn, anything, source, requiresImmediateIdAccess);
            this.PerformSaved(entity);

            return obj;
        }

        protected abstract void PerformSaved(object entity);
        protected abstract void PerformSaving(object entity);
    }
}
