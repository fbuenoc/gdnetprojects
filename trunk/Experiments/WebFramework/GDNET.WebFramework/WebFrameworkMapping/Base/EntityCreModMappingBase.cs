using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

using GDNET.Common.Base.Entities;

namespace WebFrameworkMapping.Base
{
    public abstract class EntityCreModMappingBase<TObject, TId> : EntityActiveMappingBase<TObject, TId> where TObject : EntityActiveBase<TId>, IEntityCreMod<TId>
    {
        public EntityCreModMappingBase(IGeneratorDef generator)
            : base(generator)
        {
            base.Property(e => e.CreatedAt);
            base.Property(e => e.CreatedBy);
            base.Property(e => e.LastModifiedAt);
            base.Property(e => e.LastModifiedBy);
        }
    }
}
