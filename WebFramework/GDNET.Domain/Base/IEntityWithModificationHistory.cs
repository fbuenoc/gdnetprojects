using GDNET.Domain.Base.Management;

namespace GDNET.Domain.Base
{
    public interface IEntityWithModificationHistory : IEntity
    {
        EntityHistory EntityHistory { get; }
        void AssureCreationHistory();
    }
}
