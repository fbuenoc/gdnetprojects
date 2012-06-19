namespace WebFramework.Widgets.Daskboard.Base
{
    public interface IModel<TId>
    {
        TId Id { get; set; }
        bool IsNew { get; }
    }
}
