using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using GDNET.Web.Common;
using GDNET.Common.MVP;
using GDNET.MvpWeb.Utils;

using WebFrameworkPresenters.Admin.Translation;

namespace WebFramework.Admin.Translation
{
    public partial class Index : PageBase<PresenterTranslationList>
    {
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            base.mode = ViewModeUtils.ParseMode();
            base.presenter = new PresenterTranslationList(this.TL, mode);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            base.presenter.Initlialize(base.IsPostBack);
        }
    }
}