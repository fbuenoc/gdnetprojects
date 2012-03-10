using WebFramework.Domain.Common;

namespace WebFramework.Domain.Base
{
    public interface IEntityWithLifeCycle
    {
        StatutLifeCycle LifeCycle { get; }
        void ApplyDefaultSettings();
    }
}
