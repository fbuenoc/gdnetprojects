using WebFramework.Domain.Base;
using WebFramework.Domain.Common;

namespace WebFramework.Domain.Extensions
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
