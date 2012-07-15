using System;
using System.Linq;
using GDNET.Domain.Base;
using GDNET.Domain.Base.SessionManagement;
using GDNET.Utils;
using NHibernate;
using NHibernate.Type;

namespace GDNET.NHibernate.Interceptors
{
    public class EntityWithModificationInterceptor : EmptyInterceptor
    {
        public override bool OnSave(object entity, object id, object[] state, string[] propertyNames, IType[] types)
        {
            this.UpdateEntity(entity, state, propertyNames);
            return base.OnSave(entity, id, state, propertyNames, types);
        }

        public override bool OnFlushDirty(object entity, object id, object[] currentState, object[] previousState, string[] propertyNames, IType[] types)
        {
            this.UpdateEntity(entity, currentState, propertyNames);
            return base.OnFlushDirty(entity, id, currentState, previousState, propertyNames, types);
        }

        private void UpdateEntity(object entity, object[] state, string[] propertyNames)
        {
            if (entity is IEntityWithModificationHistory)
            {
                //var entityWithModificationHistory = (IEntityWithModificationHistory)entity;
                //entityWithModificationHistory.AssureCreationHistory();

                //if ((entityWithModificationHistory.EntityHistory.FirstLog == null) && (entityWithModificationHistory.EntityHistory.LastLog == null))
                //{
                //    entityWithModificationHistory.EntityHistory.AddLog("Interceptor", null);
                //}
                //else
                //{
                //    bool? isTransient = this.IsTransient(entityWithModificationHistory.EntityHistory.Logs.Last());
                //    if (isTransient.HasValue && !isTransient.Value)
                //    {
                //        entityWithModificationHistory.EntityHistory.AddLog("Interceptor", null);
                //    }
                //}
            }

            if (entity is IEntityWithModification)
            {
                var defaultObject = default(IEntityWithModification);
                var entityWithModification = (IEntityWithModification)entity;

                var propertyCreatedAt = ExpressionAssistant.GetPropertyName(() => defaultObject.CreatedAt);
                var propertyCreatedBy = ExpressionAssistant.GetPropertyName(() => defaultObject.CreatedBy);
                var propertyLastModifiedAt = ExpressionAssistant.GetPropertyName(() => defaultObject.LastModifiedAt);
                var propertyLastModifiedBy = ExpressionAssistant.GetPropertyName(() => defaultObject.LastModifiedBy);

                if (string.IsNullOrEmpty(entityWithModification.CreatedBy))
                {
                    var propertyIndex = propertyNames.ToList().IndexOf(propertyCreatedAt);
                    state[propertyIndex] = DateTime.Now;

                    propertyIndex = propertyNames.ToList().IndexOf(propertyCreatedBy);
                    state[propertyIndex] = DomainSessionContext.Instance.CurrentUser.Email;
                }
                else
                {
                    var propertyIndex = propertyNames.ToList().IndexOf(propertyLastModifiedAt);
                    state[propertyIndex] = DateTime.Now;

                    propertyIndex = propertyNames.ToList().IndexOf(propertyLastModifiedBy);
                    state[propertyIndex] = DomainSessionContext.Instance.CurrentUser.Email;
                }
            }
        }
    }
}
