using WebFrameworkDomain.Base;
using WebFrameworkDomain.Common;

namespace WebFrameworkDomain.Extensions
{
    public static class EntityLifeCycleAssistant
    {
        public static void AddStatutLog(this IEntityWithLifeCycle entityWithLifeCycle, string userName, ListValue statut)
        {
            StatutLog statutLog = StatutLog.Factory.Create(userName, statut);
            entityWithLifeCycle.LifeCycle.AddStatutLog(statutLog);
        }
    }
}
