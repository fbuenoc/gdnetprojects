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
using GDNET.Web.Helpers;

namespace WebFramework.Admin.Translation
{
    public partial class Detail : PageBase<PresenterTranslationDetail>
    {
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            base.mode = ViewModeUtils.ParseMode();
            base.presenter = new PresenterTranslationDetail(this.TD, base.mode);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            long translationId = QueryStringHelper.ParseInteger(QueryStringConstants.ElementId);
            base.presenter.CurrentView.ElementId = translationId;
            base.presenter.Initlialize(base.IsPostBack);
        }
    }
}