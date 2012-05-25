using GDNET.Common.Base.Entities;
using GDNET.Common.Base.Meta;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace WebFramework.Base.Mapping
{
    public abstract class EntityBaseMapping<TObject, TId> : ClassMapping<TObject> where TObject : EntityBase<TId>
    {
        public EntityBaseMapping(IGeneratorDef generator)
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
