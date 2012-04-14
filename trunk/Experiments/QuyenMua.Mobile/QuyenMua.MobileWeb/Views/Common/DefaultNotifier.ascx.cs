using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using GDNET.Common.MVP;

namespace QuyenMua.MobileWeb.Views.Common
{
    public partial class DefaultNotifier : UserControl, IViewNotification
    {
        private bool isError = false;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        #region IViewNotification Members

        public bool IsError
        {
            get { return this.isError; }
            set
            {
                this.isError = value;
                if (this.isError)
                {
                    // TODO: change css for error text
                }
            }
        }

        public string Message
        {
            get { return this.lm.Text; }
            set
            {
                this.lm.Text = value;

                if (!string.IsNullOrEmpty(this.lm.Text) && !string.IsNullOrEmpty(this.lm.Text.Trim()))
                {
                    this.Visible = true;
                }
                else
                {
                    this.Visible = false;
                }
            }
        }

        #endregion
    }
}