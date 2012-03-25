using System;
using GDNET.Common.Base.Entities;
using GDNET.Common.Security.DefaultImpl;
using WebFramework.Domain.Common;
using WebFramework.Domain.Constants;

namespace WebFramework.Domain.Base
{
    public class GenericSpecification<TEntity, TId> : AbstractSpecification<TEntity, TId> where TEntity : IEntityWithActiveBase<TId>
    {
        public override bool OnSaved(TEntity entity)
        {
            if (entity is IEntityWithLifeCycle)
            {
                var lifeCycle = ((IEntityWithLifeCycle)entity).LifeCycle;
                this.AddStatutLog(lifeCycle, ListValueConstants.StatutLogs.Created);
            }

            return base.OnSaved(entity);
        }

        public override bool OnUpdated(TEntity entity)
        {
            if (entity is IEntityWithLifeCycle)
            {
                var lifeCycle = ((IEntityWithLifeCycle)entity).LifeCycle;
                this.AddStatutLog(lifeCycle, ListValueConstants.StatutLogs.Updated);
            }

            return base.OnUpdated(entity);
        }

        public override bool OnDeleted(TEntity entity)
        {
            if (entity is IEntityWithLifeCycle)
            {
                var lifeCycle = ((IEntityWithLifeCycle)entity).LifeCycle;
                this.AddStatutLog(lifeCycle, ListValueConstants.StatutLogs.Deleted);
            }

            return base.OnDeleted(entity);
        }

        private void AddStatutLog(StatutLifeCycle lifeCycle, string statutLogCode)
        {
            ListValue statut = DomainRepositories.ListValue.FindByName(statutLogCode);
            var statutLog = StatutLog.Factory.Create(SessionService.Instance.User.Identity.Name, string.Empty, DateTime.Now, statut);
            lifeCycle.AddStatutLog(statutLog);
        }

    }
}
