namespace GDNET.Common.Adapters
{
    public interface IAdapterDataPager
    {
        int PageSize { get; set; }
        int TotalRowCount { get; }

        void SetPageProperties(int startRowIndex, int maximumRows, bool databind);
    }
}
