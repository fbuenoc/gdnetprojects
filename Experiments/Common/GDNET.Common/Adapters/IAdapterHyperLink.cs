using GDNET.Common.Adapters.Base;

namespace GDNET.Common.Adapters
{
    public interface IAdapterHyperLink : IAdapterTooltipBase, IAdapterTextBase
    {
        string NavigateUrl { get; set; }
    }
}
