﻿using GDNET.Domain.Base;
using GDNET.Utils;
using NHibernate.Mapping.ByCode;

namespace GDNET.Data.Base
{
    public abstract class AbstractEntityWithModificationTMapping<TObject, TId> : AbstractEntityTMapping<TObject, TId>
        where TObject : AbstractEntityWithModificationT<TId>
    {
        public AbstractEntityWithModificationTMapping(IGeneratorDef generator)
            : base(generator)
        {
            var defaultEntity = default(AbstractEntityWithModificationT<TId>);

            base.Id<TId>(e => e.Id, m =>
            {
                m.Generator(generator);
                m.Column(ExpressionAssistant.GetPropertyName(() => defaultEntity.Id));
                m.Access(Accessor.Field);
            });

            base.Property(e => e.CreatedAt, m =>
            {
                m.Column(ExpressionAssistant.GetPropertyName(() => defaultEntity.CreatedAt));
                m.Access(Accessor.Field);
            });
            base.Property(e => e.CreatedBy, m =>
            {
                m.Column(ExpressionAssistant.GetPropertyName(() => defaultEntity.CreatedBy));
                m.Access(Accessor.Field);
            });
            base.Property(e => e.LastModifiedAt, m =>
            {
                m.Column(ExpressionAssistant.GetPropertyName(() => defaultEntity.LastModifiedAt));
                m.Access(Accessor.Field);
            });
            base.Property(e => e.LastModifiedBy, m =>
            {
                m.Column(ExpressionAssistant.GetPropertyName(() => defaultEntity.LastModifiedBy));
                m.Access(Accessor.Field);
            });
        }
    }
}