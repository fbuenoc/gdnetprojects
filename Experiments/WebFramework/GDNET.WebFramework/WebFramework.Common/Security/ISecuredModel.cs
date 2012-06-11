namespace WebFramework.Common.Security
{
    public interface ISecuredModel
    {
        bool CanAdminister { get; }
    }
}
