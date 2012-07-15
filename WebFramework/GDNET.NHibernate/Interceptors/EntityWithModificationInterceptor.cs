using GDNET.Domain.Base;
using NHibernate;
using NHibernate.Type;

namespace GDNET.NHibernate.Interceptors
{
    public class EntityWithModificationInterceptor : EmptyInterceptor
    {
        public override bool OnSave(object entity, object id, object[] state, string[] propertyNames, IType[] types)
        {
            this.UpdateEntity(entity);
            return base.OnSave(entity, id, state, propertyNames, types);
        }

        public override bool OnFlushDirty(object entity, object id, object[] currentState, object[] previousState, string[] propertyNames, IType[] types)
        {
            this.UpdateEntity(entity);
            return base.OnFlushDirty(entity, id, currentState, previousState, propertyNames, types);
        }

        private void UpdateEntity(object entity)
        {
            if (entity is IEntityWithModification)
            {
                ((IEntityWithModification)entity).InitializeModificationInfos();
            }

            if (entity is IEntityWithModificationHistory)
            {
                ((IEntityWithModificationHistory)entity).AssureCreationHistory();
                ((IEntityWithModificationHistory)entity).EntityHistory.AddLog("Creation", string.Empty);
            }
        }
    }
}
