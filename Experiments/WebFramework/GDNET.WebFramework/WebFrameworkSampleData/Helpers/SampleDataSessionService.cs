using GDNET.Common.Security;
using GDNET.Common.Security.DefaultImpl;

namespace WebFramework.Data.UnitTest
{
    public class SampleDataSessionService : SessionService
    {
        private static readonly SessionService _instance = new SampleDataSessionService();

        public SampleDataSessionService()
            : base(_instance)
        {
            base.User = new FakePrincipal();
            base.IsAuthenticated = true;
        }
    }
}
