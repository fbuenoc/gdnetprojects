namespace WebFramework.Domain.System
{
    public partial class RegionSetting
    {
        public static RegionSettingFactory Factory
        {
            get { return new RegionSettingFactory(); }
        }

        public class RegionSettingFactory
        {
            public RegionSetting Create(Region region, WidgetProperty property)
            {
                return new RegionSetting()
                {
                    Region = region,
                    WidgetProperty = property
                };
            }
        }
    }
}
