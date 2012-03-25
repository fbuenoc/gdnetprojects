using WebFramework.Domain.Common;

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
            public Widget Create(string code, string name)
            {
                var widget = new Widget
                {
                    Code = code,
                    Name = Translation.Factory.Create(string.Format("W-N|{0}", code), name),
                    Description = Translation.Factory.Create(string.Format("W-D|{0}", code), string.Empty)
                };

                return widget;
            }
        }
    }
}
