namespace WebFramework.Common.Framework.Base
{
    public interface IViewModel<TId>
    {
        TId Id { get; set; }
    }
}
