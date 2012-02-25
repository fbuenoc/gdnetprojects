using GDNET.Web.Common;
using GDNET.MvpWeb.Utils;

using WebFrameworkPresenters.Admin.Translation;

namespace WebFramework.Admin.Translation
{
    public partial class Index : PageBase
    {
        public override void PageInit()
        {
            base.mode = ViewModeUtils.ParseMode();
            base.presenter = new PresenterTranslationList(this.TL, mode);
        }

        public override void PageLoad()
        {
            base.presenter.Initlialize(base.IsPostBack);
        }
    }
}