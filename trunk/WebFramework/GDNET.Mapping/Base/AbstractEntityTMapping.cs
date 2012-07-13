using GDNET.Domain.Base;
using GDNET.Utils;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace GDNET.Data.Base
{
    public abstract class AbstractEntityTMapping<TObject, TId> : ClassMapping<TObject>
        where TObject : AbstractEntityT<TId>
    {
        public AbstractEntityTMapping(IGeneratorDef generator)
        {
            var defaultEntity = default(AbstractEntityT<TId>);

            base.Lazy(true);
            base.Id<TId>(e => e.Id, m =>
            {
                m.Generator(generator);
                m.Column(ExpressionAssistant.GetPropertyName(() => defaultEntity.Id));
                m.Access(Accessor.Field);
            });
        }
    }
}
