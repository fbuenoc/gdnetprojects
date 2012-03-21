using WebFramework.Domain;

namespace WebFramework.UI.Helpers
{
    public partial class WebFrameworkFactory
    {
        public string FormatNumber(object number)
        {
            return DomainServices.Formatter.FormatNumber(number);
        }
    }
}
