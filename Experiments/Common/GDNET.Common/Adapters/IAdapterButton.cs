using System;

using GDNET.Common.Adapters.Base;

namespace GDNET.Common.Adapters
{
    public interface IAdapterButton : IAdapterTooltipBase, IAdapterTextBase, IAdapterCommandBase
    {
        event EventHandler Click;
        string OnClientClick { get; set; }
    }
}
