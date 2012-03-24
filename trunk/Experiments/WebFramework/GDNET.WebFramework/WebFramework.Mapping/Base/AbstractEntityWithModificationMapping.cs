using GDNET.Common.Base.Entities;
using NHibernate.Mapping.ByCode;

namespace WebFramework.Mapping.Base
{
    public abstract class AbstractEntityWithModificationMapping<TObject, TId> : AbstractEntityWithActiveMapping<TObject, TId>
        where TObject : EntityWithModificationBase<TId>
    {
        public AbstractEntityWithModificationMapping(IGeneratorDef generator)
            : base(generator)
        {
            base.Property(e => e.IsDeletable);
            base.Property(e => e.IsEditable);
            base.Property(e => e.IsViewable);
        }
    }
}
