namespace WebFramework.Common.Framework.Base
{
    public interface IModel<TId>
    {
        TId Id { get; set; }
    }
}
