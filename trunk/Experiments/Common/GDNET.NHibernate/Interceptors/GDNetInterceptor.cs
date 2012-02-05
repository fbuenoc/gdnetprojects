using System.Diagnostics;
using NHibernate;
using NHibernate.Type;

namespace GDNET.NHibernate.Interceptors
{
    public class GDNetInterceptor : EmptyInterceptor
    {
        public override bool OnFlushDirty(object entity, object id, object[] currentState, object[] previousState, string[] propertyNames, IType[] types)
        {
            if (previousState != null)
            {
                for (int i = 0; i < propertyNames.Length; i++)
                {
                    Debug.WriteLine(string.Format("{0}: Previous value = {1}, Current value = {2}", propertyNames[i], previousState[i], currentState[i]));
                }
            }

            return base.OnFlushDirty(entity, id, currentState, previousState, propertyNames, types);
        }
    }
}
