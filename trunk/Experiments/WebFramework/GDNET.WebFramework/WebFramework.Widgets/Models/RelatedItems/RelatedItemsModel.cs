using System.Collections.Generic;
using WebFramework.Common.Framework.Common;
using WebFramework.Common.Framework.System;
using WebFramework.Common.Widgets;
using WebFramework.Domain.Common;

namespace WebFramework.Widgets.Models.RelatedItems
{
    public class RelatedItemsModel : WidgetModelBase
    {
        private List<ContentItemModel> relatedItems = new List<ContentItemModel>();

        public RelatedItemsModel(RegionModel regionModel)
            : base(regionModel)
        {
        }

        public IList<ContentItemModel> RelatedItems
        {
            get { return this.relatedItems; }
        }

        public RelatedItemsModel InitializeModel(ContentItem sourceItem)
        {
            this.relatedItems.Clear();

            if (sourceItem != null)
            {
                var itemModel = new ContentItemModel(sourceItem);
                this.relatedItems.AddRange(itemModel.RelatedItems);
            }

            return this;
        }
    }
}