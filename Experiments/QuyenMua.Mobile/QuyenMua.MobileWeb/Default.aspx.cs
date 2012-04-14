using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using QuyenMua.Presenters;
using GDNET.Common.MVP;
using GDNET.MvpWeb.Utils;

namespace QuyenMua.MobileWeb
{
    public partial class Default : Page
    {
        private PresenterTransactionList presenter = null;

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            ViewMode mode = ViewModeUtils.ParseMode();
            this.presenter = new PresenterTransactionList(this.l, mode);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.presenter.Initlialize();
        }
    }
}