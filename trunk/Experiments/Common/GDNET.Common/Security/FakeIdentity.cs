using System.Security.Principal;

namespace GDNET.Common.Security
{
    public class FakeIdentity : IIdentity
    {
        public string AuthenticationType
        {
            get { return "Unknow"; }
        }

        public bool IsAuthenticated
        {
            get { return false; }
        }

        public string Name
        {
            get { return "WebFramework"; }
        }
    }
}
