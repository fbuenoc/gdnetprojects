using GDNET.Common.Base.Entities;
using NHibernate.Mapping.ByCode;

namespace WebFrameworkMapping.Base
{
    public abstract class EntityFullControlMappingBase<TObject, TId> : EntityCreModMappingBase<TObject, TId> where TObject : EntityWithFullInfoBase<TId>
    {
        public EntityFullControlMappingBase(IGeneratorDef generator)
            : base(generator)
        {
            base.Property(e => e.IsDeletable);
            base.Property(e => e.IsEditable);
            base.Property(e => e.IsViewable);
        }
    }
}
