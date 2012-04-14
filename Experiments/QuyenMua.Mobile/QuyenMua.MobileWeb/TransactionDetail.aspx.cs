using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using GDNET.Common.MVP;
using GDNET.MvpWeb;
using GDNET.MvpWeb.Utils;

using QuyenMua.Presenters;

namespace QuyenMua.MobileWeb
{
    public partial class TransactionDetail : Page
    {
        private PresenterTransactionDetail presenter;

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            ViewMode currentMode = ViewModeUtils.ParseMode();
            this.presenter = new PresenterTransactionDetail(this.d, currentMode);
            this.presenter.Initlialize();

            bool result = this.presenter.Perform(base.IsPostBack);
        }
    }
}