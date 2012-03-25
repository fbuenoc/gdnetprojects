namespace WebFramework.Base.Widgets
{
    public interface IWidget
    {
        bool Initialize();
        bool Install();
        bool Uninstall();
        bool Display();
    }
}
