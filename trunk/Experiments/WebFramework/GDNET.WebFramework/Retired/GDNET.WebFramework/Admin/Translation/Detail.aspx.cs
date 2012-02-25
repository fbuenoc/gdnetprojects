using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using GDNET.Common.MVP;
using GDNET.MvpWeb.Utils;
using GDNET.Web.Common;
using GDNET.Web.Helpers;

using WebFrameworkPresenters.Admin.Translation;

namespace WebFramework.Admin.Translation
{
    public partial class Detail : DetailPageBase
    {
        public override void PageInit()
        {
            base.mode = ViewModeUtils.ParseMode();
            base.presenter = new PresenterTranslationDetail(this.TD, base.mode);
        }

        public override void PageLoad()
        {
            base.PageLoad();
            base.presenter.Initlialize(base.IsPostBack);
        }
    }
}