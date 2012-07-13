using GDNET.Domain.Base;
using NHibernate;
using NHibernate.Type;

namespace GDNET.NHibernate.Interceptors
{
    public class EntityWithModificationInterceptor : EmptyInterceptor
    {
        public override bool OnFlushDirty(object entity, object id, object[] currentState, object[] previousState, string[] propertyNames, IType[] types)
        {
            if (entity is IEntityWithModification)
            {
                ((IEntityWithModification)entity).InitializeModificationInfos();
            }

            return base.OnFlushDirty(entity, id, currentState, previousState, propertyNames, types);
        }
    }
}
