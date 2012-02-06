using System.Web.UI.WebControls;

using GDNET.Common.Adapters;

namespace GDNET.Web.Adapters
{
    public class AdapterDataPager : IAdapterDataPager
    {
        private DataPager dataPager;

        public AdapterDataPager(DataPager dataPager)
        {
            this.dataPager = dataPager;
        }

        public int PageSize
        {
            get { return this.dataPager.PageSize; }
            set { this.dataPager.PageSize = value; }
        }

        public int TotalRowCount
        {
            get { return this.dataPager.TotalRowCount; }
        }

        public void SetPageProperties(int startRowIndex, int maximumRows, bool databind)
        {
            this.dataPager.SetPageProperties(startRowIndex, maximumRows, databind);
        }
    }
}
