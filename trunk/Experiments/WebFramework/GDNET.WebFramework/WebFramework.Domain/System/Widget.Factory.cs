namespace WebFramework.Domain.System
{
    public partial class Widget
    {
        public static WidgetFactory Factory
        {
            get { return new WidgetFactory(); }
        }

        public class WidgetFactory
        {
            public Widget Create()
            {
                var w = new Widget();
                return w;
            }
        }
    }
}
