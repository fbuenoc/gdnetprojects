using System;
using WebFramework.Domain.System;

namespace WebFramework.Common.Widgets
{
    public class WidgetEventArgs : EventArgs
    {
        public Widget Instance
        {
            get;
            private set;
        }

        public WidgetEventArgs(Widget instance)
            : base()
        {
            this.Instance = instance;
        }
    }
}
