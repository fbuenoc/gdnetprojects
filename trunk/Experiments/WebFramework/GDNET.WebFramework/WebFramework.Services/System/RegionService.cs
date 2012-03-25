using WebFramework.Domain.Services;
using WebFramework.Domain.System;

namespace WebFramework.Services.System
{
    public sealed class RegionService : IRegionService
    {
        public void ApplyDefaultProperties(Region region)
        {
            if (region.Widget != null)
            {
                foreach (var property in region.Widget.Properties)
                {
                    RegionSetting setting = RegionSetting.Factory.Create(property, property.Value);
                    region.AddSetting(setting);
                }
            }
        }
    }
}
