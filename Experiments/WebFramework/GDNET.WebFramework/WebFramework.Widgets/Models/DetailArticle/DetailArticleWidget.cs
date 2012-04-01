using GDNET.Web.Helpers;
using WebFramework.Common.Common;
using WebFramework.Common.Widgets;
using WebFramework.Domain;

namespace WebFramework.Widgets.Models.DetailArticle
{
    public class DetailArticleWidget : WidgetBase<DetailArticleModel>
    {
        public override string Code
        {
            get { return "A9CD5BF8-460A-41EB-ACC1-2C4313D1D74F"; }
        }

        public DetailArticleWidget()
            : base()
        {
        }

        #region Events
        #endregion

        protected override DetailArticleModel InitializeModel()
        {
            DetailArticleModel resultModel = new DetailArticleModel(base.region);

            long? contentItemId = QueryStringAssistant.ParseInteger(EntityQueryString.ContentItemId);
            if (contentItemId.HasValue)
            {
                var contentItemObject = DomainRepositories.ContentItem.GetById(contentItemId.Value);
                resultModel.InitializeModel(contentItemObject);
            }

            return resultModel;
        }

    }
}