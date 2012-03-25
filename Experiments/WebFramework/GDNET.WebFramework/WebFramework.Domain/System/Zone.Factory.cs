namespace WebFramework.Domain.System
{
    public partial class Zone
    {
        public static ZoneFactory Factory
        {
            get { return new ZoneFactory(); }
        }

        public class ZoneFactory
        {
            public Zone Create(string code, string description)
            {
                var zone = new Zone()
                {
                    Code = code,
                    Description = description
                };
                return zone;
            }
        }
    }
}
