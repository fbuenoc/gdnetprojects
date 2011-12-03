using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

using GDNET.Common.Base.Entities;

namespace WebFrameworkMapping.Base
{
    public abstract class EntityFullControlMappingBase<TObject, TId> : EntityCreModMappingBase<TObject, TId> where TObject : EntityFullControlBase<TId>
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
