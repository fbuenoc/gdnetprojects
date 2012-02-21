using GDNET.Common.Base.Entities;
using NHibernate.Mapping.ByCode;

namespace WebFrameworkMapping.Base
{
    public abstract class AbstractEntityMappingWithModification<TObject, TId> : AbstractEntityMapping<TObject, TId>
        where TObject : EntityWithModificationBase<TId>
    {
        public AbstractEntityMappingWithModification(IGeneratorDef generator)
            : base(generator)
        {
            base.Property(e => e.IsActive);
            base.Property(e => e.IsDeletable);
            base.Property(e => e.IsEditable);
            base.Property(e => e.IsViewable);
        }
    }
}
