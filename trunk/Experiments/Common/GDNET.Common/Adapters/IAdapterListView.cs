using System;

using GDNET.Common.Adapters.Base;
using System.Collections;

namespace GDNET.Common.Adapters
{
    public delegate void PagePropertiesChangingHandler(int startRowIndex, int maximumRows);

    public interface IAdapterListView : IAdapterTooltipBase, IAdapterControlBase
    {
        event EventHandler SelectedIndexChanged;
        event PagePropertiesChangingHandler PagePropertiesChanging;

        object DataSource { get; set; }
        void SetPagedDataSource(IEnumerable dataSource, int totalRowCount, int startRowIndex, int maximumRows);
    }
}
