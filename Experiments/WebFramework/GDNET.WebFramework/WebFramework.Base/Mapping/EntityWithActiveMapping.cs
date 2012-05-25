using GDNET.Common.Base.Entities;
using NHibernate.Mapping.ByCode;

namespace WebFramework.Base.Mapping
{
    public abstract class EntityWithActiveMapping<TObject, TId> : EntityBaseMapping<TObject, TId> where TObject : EntityWithActive<TId>
    {
        public EntityWithActiveMapping(IGeneratorDef generator)
            : base(generator)
        {
            base.Property(e => e.IsActive);
        }
    }
}
