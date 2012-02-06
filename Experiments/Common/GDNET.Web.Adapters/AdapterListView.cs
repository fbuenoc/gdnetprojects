using System;
using System.Collections;
using System.Web.UI.WebControls;

using GDNET.Common.Adapters;
using GDNET.Web.MultilingualControls;
using ListView = GDNET.Web.MultilingualControls.ListView;

namespace GDNET.Web.Adapters
{
    public class AdapterListView : IAdapterListView
    {
        public ListView ListView
        {
            get;
            private set;
        }

        public AdapterListView(ListView listView)
        {
            this.ListView = listView;
            this.ListView.SelectedIndexChanged += new EventHandler(OnSelectedIndexChanged);
            this.ListView.PagePropertiesChanging += new EventHandler<PagePropertiesChangingEventArgs>(OnPagePropertiesChanging);
        }

        #region Events

        protected void OnPagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            if (this.PagePropertiesChanging != null)
            {
                this.PagePropertiesChanging(e.StartRowIndex, e.MaximumRows);
            }
        }

        protected void OnSelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.SelectedIndexChanged != null)
            {
                this.SelectedIndexChanged(sender, e);
            }
        }

        #endregion

        #region IAdapterListView Members

        public event EventHandler SelectedIndexChanged;
        public event PagePropertiesChangingHandler PagePropertiesChanging;

        public object DataSource
        {
            get { return this.ListView.DataSource; }
            set
            {
                this.ListView.DataSource = value;
                this.ListView.DataBind();
            }
        }

        public string Tooltip
        {
            get { return this.ListView.ToolTip; }
            set { this.ListView.ToolTip = Tooltip; }
        }

        public string TooltipCode
        {
            get { return this.ListView.TooltipCode; }
            set { this.ListView.TooltipCode = value; }
        }

        public bool Enable
        {
            get { return this.ListView.Enabled; }
            set { this.ListView.Enabled = value; }
        }

        public bool Visible
        {
            get { return this.ListView.Visible; }
            set { this.ListView.Visible = value; }
        }

        public void SetPagedDataSource(IEnumerable dataSource, int totalRowCount, int startRowIndex, int maximumRows)
        {
            ListViewPagedDataSource ds = new ListViewPagedDataSource();
            ds.AllowServerPaging = true;
            ds.DataSource = dataSource;
            ds.TotalRowCount = totalRowCount;
            ds.MaximumRows = maximumRows;
            ds.StartRowIndex = startRowIndex;
            this.DataSource = ds;
        }

        #endregion

    }
}
