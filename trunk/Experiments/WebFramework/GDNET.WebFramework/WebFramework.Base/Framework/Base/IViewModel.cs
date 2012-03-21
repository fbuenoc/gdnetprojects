namespace WebFramework.Base.Framework.Base
{
    public interface IViewModel<TId>
    {
        TId Id { get; set; }
    }
}
