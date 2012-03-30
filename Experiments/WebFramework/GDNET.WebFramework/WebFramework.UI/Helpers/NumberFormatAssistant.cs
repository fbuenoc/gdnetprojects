using WebFramework.Domain;

namespace WebFramework.UI.Helpers
{
    public class NumberFormatAssistant
    {
        public string FormatNumber(object number)
        {
            return DomainServices.Formatter.FormatNumber(number);
        }
    }
}
