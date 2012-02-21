using System;
using System.Security.Principal;

namespace GDNET.Common.Security
{
    [Serializable]
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
            get { return "GDNET"; }
        }
    }
}
