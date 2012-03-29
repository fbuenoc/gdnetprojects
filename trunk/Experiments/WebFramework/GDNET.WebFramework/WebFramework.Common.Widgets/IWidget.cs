using System;
using WebFramework.Common.Framework.System;

namespace WebFramework.Common.Widgets
{
    public interface IWidget
    {
        event EventHandler BeforeInstalled;
        event WidgetEventHandler AfterInstalled;

        bool Install();
        bool Uninstall();

        object Initialize(RegionModel region);
    }
}
