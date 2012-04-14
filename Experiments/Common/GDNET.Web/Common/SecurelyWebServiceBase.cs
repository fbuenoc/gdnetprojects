using System.Web.Services;

namespace GDNET.Web.Common
{
    public abstract class SecurelyWebServiceBase : WebService
    {
        protected bool ValidateSecurity()
        {
            return true;
        }

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
    }
}
