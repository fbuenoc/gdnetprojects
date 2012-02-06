using System;

using GDNET.Common.Adapters;
using GDNET.Web.MultilingualControls;

namespace GDNET.Web.Adapters
{
    public class AdapterButton : IAdapterButton
    {
        private Button button;

        public AdapterButton(Button button)
        {
            this.button = button;
            this.button.Click += new EventHandler(OnClick);
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

        #region Properties

        #region IAdapterHyperLink Members

        public event EventHandler Click;

        public string OnClientClick
        {
            get { return this.button.OnClientClick; }
            set { this.button.OnClientClick = value; }
        }

        public string Tooltip
        {
            get { return this.button.ToolTip; }
            set { this.button.ToolTip = Tooltip; }
        }

        public string TooltipCode
        {
            get { return this.button.TooltipCode; }
            set { this.button.TooltipCode = value; }
        }

        public string CommandArgument
        {
            get { return this.button.CommandArgument; }
            set { this.button.CommandArgument = value; }
        }

        public string CommandName
        {
            get { return this.button.CommandName; }
            set { this.button.CommandName = value; }
        }

        public string Text
        {
            get { return this.button.Text; }
            set { this.button.Text = value; }
        }

        public string TextCode
        {
            get { return this.button.TextCode; }
            set { this.button.TextCode = value; }
        }

        public bool Enable
        {
            get { return this.button.Enabled; }
            set { this.button.Enabled = value; }
        }

        public bool Visible
        {
            get { return this.button.Visible; }
            set { this.button.Visible = value; }
        }

        #endregion

        #endregion

    }
}
