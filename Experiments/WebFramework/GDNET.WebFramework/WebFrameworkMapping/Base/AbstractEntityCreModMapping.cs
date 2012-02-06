using GDNET.Common.Base.Entities;
using NHibernate.Mapping.ByCode;

namespace WebFrameworkMapping.Base
{
    public abstract class EntityCreModMappingBase<TObject, TId> : EntityActiveMappingBase<TObject, TId> where TObject : EntityWithActiveBase<TId>, IEntityWithModification<TId>
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
