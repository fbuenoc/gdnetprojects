using GDNET.Domain.Base.Management;

namespace GDNET.Domain.Base
{
    public interface IEntityWithModificationHistory : IEntityWithModification
    {
        EntityHistory History { get; }
    }
}
