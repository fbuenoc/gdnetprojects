namespace GDNET.Web.Mvc.Services
{
    public interface IAuthorizationService
    {
        bool ActionIsAllowedForUser(string controllerName, string actionName);
        bool ActionIsAllowedForUser(string controllerName, params string[] actionsName);
    }
}
