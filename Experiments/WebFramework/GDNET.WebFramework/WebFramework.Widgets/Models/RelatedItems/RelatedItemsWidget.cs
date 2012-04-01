using System;
using GDNET.Web.Helpers;
using WebFramework.Common.Common;
using WebFramework.Common.Widgets;
using WebFramework.Domain;

namespace WebFramework.Widgets.Models.RelatedItems
{
    public class RelatedItemsWidget : WidgetBase<RelatedItemsModel>
    {
        public override string Code
        {
            get { return "0A939BA9-13B0-4568-A5A9-66F469E5A5FE"; }
        }

        public RelatedItemsWidget()
        {
            base.BeforeInstalled += WidgetBeforeInstalled;
            base.AfterInstalled += WidgetAfterInstalled;
        }

        #region Events

        void WidgetBeforeInstalled(object sender, EventArgs e)
        {
        }

        void WidgetAfterInstalled(IWidget sender, WidgetEventArgs e)
        {
        }

        #endregion

        protected override void RegisterProperties()
        {
            base.RegisterProperties();
            base.RegisterProperty(WidgetBaseConstants.PropertyPageSize, WidgetBaseConstants.DefaultPageSize.ToString());
        }

        protected override RelatedItemsModel InitializeModel()
        {
            RelatedItemsModel resultModel = new RelatedItemsModel(base.region);

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