using System;

using GDNET.Common.Adapters.Base;

namespace GDNET.Common.Adapters
{
    public interface IAdapterTextBox : IAdapterTooltipBase, IAdapterTextBase
    {
        event EventHandler TextChanged;

        bool ReadOnly { get; set; }
    }
}
