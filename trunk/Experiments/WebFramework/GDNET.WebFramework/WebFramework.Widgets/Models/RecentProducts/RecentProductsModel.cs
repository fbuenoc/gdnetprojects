using System.Collections.Generic;
using System.Linq;
using WebFramework.Common.Framework.Common;
using WebFramework.Common.Framework.System;
using WebFramework.Common.Widgets;
using WebFramework.Domain.Common;

namespace WebFramework.Widgets.Models.RecentProducts
{
    public class RecentProductsModel : WidgetModelBase
    {
        public RecentProductsModel(RegionModel regionModel)
            : base(regionModel)
        {
        }

        public IList<ContentItemModel> Products
        {
            get;
            private set;
        }

        public void InitializeProducts(IList<ContentItem> products)
        {
            this.Products = products.Select(x => new ContentItemModel(x)).ToList();
        }
    }
}