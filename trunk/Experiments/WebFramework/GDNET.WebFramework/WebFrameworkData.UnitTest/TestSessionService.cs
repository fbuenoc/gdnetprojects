using System.Security.Principal;

using GDNET.Common.Base;
using GDNET.Common.Security;
using GDNET.Common.Security.DefaultImpl;

namespace WebFramework.Data.UnitTest
{
    public class TestSessionService : SessionService
    {
        private static readonly TestSessionService _instance = new TestSessionService();

        public TestSessionService()
            : base(_instance)
        {
            base.User = new FakePrincipal();
            base.IsAuthenticated = false;
        }
    }
}
