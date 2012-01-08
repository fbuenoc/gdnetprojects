using System;
using System.Security.Principal;

namespace GDNET.Common.Security
{
    [Serializable]
    public class FakePrincipal : IPrincipal
    {
        public IIdentity Identity
        {
            get { return new FakeIdentity(); }
        }

        public bool IsInRole(string role)
        {
            return false;
        }
    }
}
