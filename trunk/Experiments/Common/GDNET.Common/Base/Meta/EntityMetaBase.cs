using GDNET.Common.Base.Entities;
using GDNET.Common.Helpers;

namespace GDNET.Common.Base.Meta
{
    public abstract class EntityMetaBase
    {
        private class EmptyEntityBase : EntityBase<int> { }
        private static readonly EmptyEntityBase emptyEntity = new EmptyEntityBase();

        //public const string Id = emptyEntity.GetPropertyName<EmptyEntityBase, int>(e => e.Id);

        public const string Signature = "Signature";
    }
}
