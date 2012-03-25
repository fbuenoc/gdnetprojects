using WebFramework.Domain.System;

namespace WebFramework.Domain.Services
{
    public interface IRegionService
    {
        /// <summary>
        /// Apply all default values of the widget for this region
        /// </summary>
        void ApplyDefaultProperties(Region region);
    }
}
