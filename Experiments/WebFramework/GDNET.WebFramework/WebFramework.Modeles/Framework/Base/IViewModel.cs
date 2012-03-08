namespace WebFramework.Models.Framework.Base
{
    public interface IViewModel<TId>
    {
        TId Id { get; }
    }
}
