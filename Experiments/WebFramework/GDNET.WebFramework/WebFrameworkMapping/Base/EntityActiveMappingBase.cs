using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

using GDNET.Common.Base.Entities;

namespace WebFrameworkMapping.Base
{
    public abstract class EntityActiveMappingBase<TObject, TId> : EntityMappingBase<TObject, TId> where TObject : EntityActiveBase<TId>
    {
        public EntityActiveMappingBase(IGeneratorDef generator)
            : base(generator)
        {
            base.Property(e => e.IsActive);
        }
    }
}
