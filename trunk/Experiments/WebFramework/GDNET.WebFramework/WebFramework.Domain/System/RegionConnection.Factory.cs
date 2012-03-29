namespace WebFramework.Domain.System
{
    public partial class RegionConnection
    {
        public static RegionConnectionFactory Factory
        {
            get { return new RegionConnectionFactory(); }
        }

        public class RegionConnectionFactory
        {
            public RegionConnection Create(Region to, string action)
            {
                var regionConnection = new RegionConnection()
                {
                    To = to,
                    Action = action
                };

                return regionConnection;
            }
        }
    }
}
