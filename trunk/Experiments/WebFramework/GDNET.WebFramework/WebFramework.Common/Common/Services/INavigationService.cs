namespace WebFramework.Common.Common.Services
{
    public interface INavigationService
    {
        string AddReturnUrl(string currentUrl);
        string AddParameter(string currentUrl, string paramName, string paramValue);
    }
}
