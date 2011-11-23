using GDNET.Common.Base.Entities;

namespace WebFrameworkDomain.Common
{
    public partial class Culture
    {
        public static CultureFactory Factory
        {
            get { return new CultureFactory(); }
        }

        public class CultureFactory
        {
            public Culture Create()
            {
                return new Culture
                {
                    IsActive = false,
                    IsDefault = false,
                };
            }
        }
    }
}
