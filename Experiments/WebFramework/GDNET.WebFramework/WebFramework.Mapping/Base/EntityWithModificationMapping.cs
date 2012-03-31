using GDNET.Common.Base.Entities;
using NHibernate.Mapping.ByCode;

namespace WebFramework.Mapping.Base
{
    public abstract class EntityWithModificationMapping<TObject, TId> : EntityWithActiveMapping<TObject, TId>
        where TObject : EntityWithModification<TId>
    {
        public EntityWithModificationMapping(IGeneratorDef generator)
            : base(generator)
        {
            base.Property(e => e.IsDeletable);
            base.Property(e => e.IsEditable);
        }
    }
}
