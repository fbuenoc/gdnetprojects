using System;
using GDNET.Domain.Base.Management;
using GDNET.NHibernate.Mapping;
using GDNET.Utils;
using NHibernate.Mapping.ByCode;

namespace GDNET.Data.Base.Management
{
    public class EntityLogMapping : AbstractEntityTMapping<EntityLog, Guid>, IEntityMapping
    {
        public EntityLogMapping()
            : base(Generators.Guid)
        {
            var defaultEntity = default(EntityLog);

            base.Property(e => e.CreatedAt, m =>
            {
                m.Column(ExpressionAssistant.GetPropertyName(() => defaultEntity.CreatedAt));
                m.Access(Accessor.Property);
            });
            base.Property(e => e.CreatedBy, m =>
            {
                m.Column(ExpressionAssistant.GetPropertyName(() => defaultEntity.CreatedBy));
                m.Access(Accessor.Property);
            });
            base.Property(e => e.LogContentText, m =>
            {
                m.Column(ExpressionAssistant.GetPropertyName(() => defaultEntity.LogContentText));
                m.Access(Accessor.Property);
            });
            base.Property(e => e.LogMessage, m =>
            {
                m.Column(ExpressionAssistant.GetPropertyName(() => defaultEntity.LogMessage));
                m.Access(Accessor.Property);
            });
        }
    }
}
