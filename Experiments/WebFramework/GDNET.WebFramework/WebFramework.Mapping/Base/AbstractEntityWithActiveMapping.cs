using GDNET.Common.Base.Entities;
using NHibernate.Mapping.ByCode;

namespace WebFramework.Mapping.Base
{
    public abstract class AbstractEntityWithActiveMapping<TObject, TId> : AbstractEntityMapping<TObject, TId> where TObject : EntityWithActiveBase<TId>
    {
        public AbstractEntityWithActiveMapping(IGeneratorDef generator)
            : base(generator)
        {
            base.Property(e => e.IsActive);
        }
    }
}
