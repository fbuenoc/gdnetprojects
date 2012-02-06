using System;

using GDNET.Common.Adapters;
using GDNET.Web.MultilingualControls;

namespace GDNET.Web.Adapters
{
    public class AdapterTextBox : IAdapterTextBox
    {
        private TextBox textBox;

        public AdapterTextBox(TextBox textBox)
        {
            this.textBox = textBox;
            this.textBox.TextChanged += new EventHandler(OnTextChanged);
        }

        #region Events

        void OnTextChanged(object sender, EventArgs e)
        {
            if (this.TextChanged != null)
            {
                this.TextChanged(this, e);
            }
        }

        #endregion

        #region Properties

        #region IAdapterTextBox Members

        public event EventHandler TextChanged;

        public bool ReadOnly
        {
            get { return this.textBox.ReadOnly; }
            set { this.textBox.ReadOnly = value; }
        }

        public string Tooltip
        {
            get { return this.textBox.ToolTip; }
            set { this.textBox.ToolTip = Tooltip; }
        }

        public string TooltipCode
        {
            get { return this.textBox.TooltipCode; }
            set { this.textBox.TooltipCode = value; }
        }

        public string Text
        {
            get { return this.textBox.Text; }
            set { this.textBox.Text = value; }
        }

        public string TextCode
        {
            get { return this.textBox.TextCode; }
            set { this.textBox.TextCode = value; }
        }

        public bool Enable
        {
            get { return this.textBox.Enabled; }
            set { this.textBox.Enabled = value; }
        }

        public bool Visible
        {
            get { return this.textBox.Visible; }
            set { this.textBox.Visible = value; }
        }

        #endregion

        #endregion
    }
}
