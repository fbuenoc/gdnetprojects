using GDNET.Common.Adapters;
using GDNET.Web.MultilingualControls;

namespace GDNET.Web.Adapters
{
    public class AdapterHyperLink : IAdapterHyperLink
    {
        private HyperLink hyperLink;

        public AdapterHyperLink(HyperLink hyperLink)
        {
            this.hyperLink = hyperLink;
        }

        #region IAdapterHyperLink Members

        public string Tooltip
        {
            get { return this.hyperLink.ToolTip; }
            set { this.hyperLink.ToolTip = Tooltip; }
        }

        public string TooltipCode
        {
            get { return this.hyperLink.TooltipCode; }
            set { this.hyperLink.TooltipCode = value; }
        }

        public string NavigateUrl
        {
            get { return this.hyperLink.NavigateUrl; }
            set { this.hyperLink.NavigateUrl = value; }
        }

        public string Text
        {
            get { return this.hyperLink.Text; }
            set { this.hyperLink.Text = value; }
        }

        public string TextCode
        {
            get { return this.hyperLink.TextCode; }
            set { this.hyperLink.TextCode = value; }
        }

        public bool Enable
        {
            get { return this.hyperLink.Enabled; }
            set { this.hyperLink.Enabled = value; }
        }

        public bool Visible
        {
            get { return this.hyperLink.Visible; }
            set { this.hyperLink.Visible = value; }
        }

        #endregion
    }
}
