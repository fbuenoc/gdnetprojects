using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

using GDNET.Common.Base.Entities;
using GDNET.Common.Base.Meta;

namespace WebFrameworkMapping.Base
{
    public abstract class EntityMappingBase<TObject, TId> : ClassMapping<TObject> where TObject : EntityBase<TId>
    {
        public EntityMappingBase(IGeneratorDef generator)
        {
            base.Lazy(true);
            base.Id<TId>(e => e.Id, m =>
            {
                m.Generator(generator);
                m.Column(MetaEntityBase.Id);
                m.Access(Accessor.Property);
            });
        }
    }
}
