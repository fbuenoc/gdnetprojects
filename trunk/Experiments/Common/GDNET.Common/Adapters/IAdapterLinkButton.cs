using System;

using GDNET.Common.Adapters.Base;

namespace GDNET.Common.Adapters
{
    public interface IAdapterLinkButton : IAdapterTooltipBase, IAdapterTextBase, IAdapterCommandBase
    {
        event EventHandler Click;
        ActionType Action { get; set; }
    }
}
