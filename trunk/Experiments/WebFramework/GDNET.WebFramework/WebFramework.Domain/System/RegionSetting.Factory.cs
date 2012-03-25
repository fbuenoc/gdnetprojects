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
            public RegionSetting Create(WidgetProperty property, string value)
            {
                return new RegionSetting()
                {
                    WidgetProperty = property,
                    Value = value
                };
            }
        }
    }
}
