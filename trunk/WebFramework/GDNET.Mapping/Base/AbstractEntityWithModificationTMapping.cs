using GDNET.Base;
using GDNET.Base.DomainAbstraction;
using NHibernate.Mapping.ByCode;

namespace GDNET.Mapping.Base
{
    public abstract class AbstractEntityWithModificationTMapping<TObject, TId> : AbstractEntityTMapping<TObject, TId>
        where TObject : AbstractEntityWithModificationT<TId>
    {
        public AbstractEntityWithModificationTMapping(IGeneratorDef generator)
            : base(generator)
        {
            base.Id<TId>(e => e.Id, m =>
            {
                m.Generator(generator);
                m.Column(EntityWithModificationMeta.Id);
                m.Access(Accessor.Field);
            });

            base.Property(e => e.CreatedAt, m =>
            {
                m.Column(EntityWithModificationMeta.CreatedAt);
                m.Access(Accessor.Field);
                m.NotNullable(true);
            });
            base.Property(e => e.CreatedBy, m =>
            {
                m.Column(EntityWithModificationMeta.CreatedBy);
                m.Access(Accessor.Field);
                m.NotNullable(true);
            });
            base.Property(e => e.LastModifiedAt, m =>
            {
                m.Column(EntityWithModificationMeta.LastModifiedAt);
                m.Access(Accessor.Field);
            });
            base.Property(e => e.LastModifiedBy, m =>
            {
                m.Column(EntityWithModificationMeta.LastModifiedBy);
                m.Access(Accessor.Field);
            });
        }
    }
}
