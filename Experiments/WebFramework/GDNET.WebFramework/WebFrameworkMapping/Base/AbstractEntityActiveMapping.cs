using GDNET.Common.Base.Entities;
using NHibernate.Mapping.ByCode;

namespace WebFrameworkMapping.Base
{
    public abstract class EntityActiveMappingBase<TObject, TId> : EntityMappingBase<TObject, TId> where TObject : EntityWithActiveBase<TId>
    {
        public EntityActiveMappingBase(IGeneratorDef generator)
            : base(generator)
        {
            base.Property(e => e.IsActive);
        }
    }
}
