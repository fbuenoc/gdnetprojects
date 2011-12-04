namespace GDNET.Common.Adapters.Base
{
    public interface IAdapterCommandBase
    {
        string CommandArgument { get; set; }
        string CommandName { get; set; }
    }
}
