using GDNET.Domain.Base;
using GDNET.Mapping.Common;
using GDNET.Utils;
using NHibernate.Mapping.ByCode.Conformist;

namespace GDNET.Mapping.Base
{
    public abstract class AbstractJoinedSubclassMapping<TObject, TId> : JoinedSubclassMapping<TObject>
        where TObject : AbstractEntityT<TId>
    {
        public AbstractJoinedSubclassMapping()
        {
            var defaultObject = default(AbstractEntityT<TId>);
            base.Table(MappingAssistant.GetStrongTableByType(typeof(TObject)));
            base.Key(km => km.Column(ExpressionAssistant.GetPropertyName(() => defaultObject.Id)));
        }
    }
}
