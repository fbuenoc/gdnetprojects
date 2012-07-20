using GDNET.Domain.Base;
using NHibernate.Mapping.ByCode;

namespace GDNET.Mapping.Base
{
    public abstract class AbstractEntityWithModificationHistoryTMapping<TObject, TId> : AbstractEntityTMapping<TObject, TId>
        where TObject : AbstractEntityWithModificationHistoryT<TId>
    {
        public AbstractEntityWithModificationHistoryTMapping(IGeneratorDef generator)
            : base(generator)
        {
        }
    }
}
