using WebFramework.Domain.Common;

namespace WebFramework.Common.Services
{
    public interface INavigationService
    {
        string GetUrlDetails(ContentItem contentItem);
    }
}
