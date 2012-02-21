using WebFrameworkDomain.Common;

namespace WebFrameworkDomain.Base
{
    public interface IEntityWithLifeCycle
    {
        StatutLifeCycle LifeCycle { get; }
        void ApplyDefaultSettings();
    }
}
