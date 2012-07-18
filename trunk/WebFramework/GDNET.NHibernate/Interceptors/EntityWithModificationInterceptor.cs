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
            return this.UpdateEntity(entity, ref state, ref propertyNames);
        }

        public override bool OnFlushDirty(object entity, object id, object[] currentState, object[] previousState, string[] propertyNames, IType[] types)
        {
            return this.UpdateEntity(entity, ref currentState, ref propertyNames);
        }

        private bool UpdateEntity(object entity, ref object[] state, ref string[] propertyNames)
        {
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
                    state[propertyIndex] = this.GetEmailCurrentUser();
                }
                else
                {
                    var propertyIndex = propertyNames.ToList().IndexOf(propertyLastModifiedAt);
                    state[propertyIndex] = DateTime.Now;

                    propertyIndex = propertyNames.ToList().IndexOf(propertyLastModifiedBy);
                    state[propertyIndex] = this.GetEmailCurrentUser();
                }
            }

            return true;
        }

        protected virtual string GetEmailCurrentUser()
        {
            return DomainSessionContext.Instance.CurrentUser.Email;
        }
    }
}
