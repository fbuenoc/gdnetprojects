using System;

using GDNET.Common.Adapters;
using GDNET.Common.Adapters.Base;

using GDNET.Web.MultilingualControls;

namespace GDNET.Web.Adapters
{
    public class AdapterLinkButton : IAdapterLinkButton
    {
        private LinkButton linkButton;

        public AdapterLinkButton(LinkButton linkButton)
        {
            this.linkButton = linkButton;
            this.linkButton.Click += new EventHandler(OnClick);
        }

        #region Events

        void OnClick(object sender, EventArgs e)
        {
            if (this.Click != null)
            {
                this.Click(this, e);
            }
        }

        #endregion

        #region IAdapterLinkButton Members

        public event EventHandler Click;

        public ActionType Action
        {
            get { return this.linkButton.Action; }
            set { this.linkButton.Action = value; }
        }

        public string Tooltip
        {
            get { return this.linkButton.ToolTip; }
            set { this.linkButton.ToolTip = Tooltip; }
        }

        public string TooltipCode
        {
            get { return this.linkButton.TooltipCode; }
            set { this.linkButton.TooltipCode = value; }
        }

        public string CommandArgument
        {
            get { return this.linkButton.CommandArgument; }
            set { this.linkButton.CommandArgument = value; }
        }

        public string CommandName
        {
            get { return this.linkButton.CommandName; }
            set { this.linkButton.CommandName = value; }
        }

        public string Text
        {
            get { return this.linkButton.Text; }
            set { this.linkButton.Text = value; }
        }

        public string TextCode
        {
            get { return this.linkButton.TextCode; }
            set { this.linkButton.TextCode = value; }
        }

        public bool Enable
        {
            get { return this.linkButton.Enabled; }
            set { this.linkButton.Enabled = value; }
        }

        public bool Visible
        {
            get { return this.linkButton.Visible; }
            set { this.linkButton.Visible = value; }
        }

        #endregion

    }
}
