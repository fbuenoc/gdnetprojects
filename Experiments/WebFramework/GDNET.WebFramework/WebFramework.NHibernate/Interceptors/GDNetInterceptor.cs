using NHibernate;
using NHibernate.Type;

namespace WebFramework.NHibernate.Interceptors
{
    public class GDNetInterceptor : EmptyInterceptor
    {
        public override bool OnFlushDirty(object entity, object id, object[] currentState, object[] previousState, string[] propertyNames, IType[] types)
        {
            return base.OnFlushDirty(entity, id, currentState, previousState, propertyNames, types);
        }
    }
}
