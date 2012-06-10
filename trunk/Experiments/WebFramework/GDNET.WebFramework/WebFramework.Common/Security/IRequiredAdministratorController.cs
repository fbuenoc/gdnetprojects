namespace WebFramework.Common.Security
{
    /// <summary>
    /// With all controllers which implement this interface, only administrator users can access its page
    /// </summary>
    public interface IRequiredAdministratorController : IRequiredAuthenticatedController
    {
    }
}
