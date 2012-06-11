using WebFramework.Common.Widgets;
using WebFramework.Domain.Constants;

namespace WebFramework.Widgets.RecentArticlesAg
{
    public class RecentArticlesWidget : WidgetBase<RecentArticlesModel>
    {
        public override string Code
        {
            get { return "9D5FA005-FBE7-4CE3-823F-B1A8A82BA532"; }
        }

        protected override RecentArticlesModel InitializeModel()
        {
            RecentArticlesModel model = base.InitializeModel();
            return model;
        }

        protected override void RegisterProperties()
        {
            base.RegisterProperties();

            this.RegisterProperty(WidgetBaseConstants.PropertyPageSize, WidgetBaseConstants.DefaultPageSize.ToString(), ListValueConstants.ContentDataTypes.NumberNormalNumber);
        }
    }
}