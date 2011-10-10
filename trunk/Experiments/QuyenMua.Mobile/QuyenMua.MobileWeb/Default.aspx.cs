using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using QuyenMua.Presenters;

namespace QuyenMua.MobileWeb
{
    public partial class Default : Page
    {
        private PresenterListTransaction presenter = null;

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            this.presenter = new PresenterListTransaction(this.l);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.presenter.Initlialize();
        }
    }
}