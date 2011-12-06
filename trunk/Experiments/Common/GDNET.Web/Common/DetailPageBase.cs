using GDNET.Common.MVP;
using GDNET.Web.Helpers;

namespace GDNET.Web.Common
{
    public abstract class DetailPageBase : PageBase
    {
        public PresenterCrudBase Presenter
        {
            get { return (PresenterCrudBase)base.presenter; }
        }

        public override void PageLoad()
        {
            if (!base.IsPostBack)
            {
                long? elementId = QueryStringHelper.ParseInteger(QueryStringConstants.ElementId);
                if (elementId.HasValue)
                {
                    this.Presenter.View.ElementId = elementId.Value;
                }
            }
        }
    }
}
