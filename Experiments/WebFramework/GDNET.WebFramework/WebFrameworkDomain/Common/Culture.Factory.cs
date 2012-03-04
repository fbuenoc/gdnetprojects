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
            internal Culture NewInstance()
            {
                return new Culture();
            }

            public Culture Create(string code)
            {
                return new Culture
                {
                    IsActive = true,
                    IsDefault = false,
                    CultureCode = code
                };
            }

        }
    }
}
