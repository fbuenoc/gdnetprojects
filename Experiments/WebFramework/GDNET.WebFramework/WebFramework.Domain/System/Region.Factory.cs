namespace WebFramework.Domain.System
{
    public partial class Region
    {
        public static RegionFactory Factory
        {
            get { return new RegionFactory(); }
        }

        public class RegionFactory
        {
            public Region Create(string name, Widget widget)
            {
                var region = new Region()
                {
                    Name = name,
                    Widget = widget,
                };

                return region;
            }
        }
    }
}
