using System;
using WebFramework.Business.Common;
using WebFramework.Common.Widgets;
using WebFramework.Domain;

namespace WebFramework.Widgets.Models.RecentProducts
{
    public class RecentProductsWidget : WidgetBase<RecentProductsModel>
    {
        public override string Code
        {
            get { return "C7E17D9B-CD37-4E4C-BD64-A03D0B8C45B8"; }
        }

        public RecentProductsWidget()
        {
            base.BeforeInstalled += RecentProductWidget_BeforeInstalled;
            base.AfterInstalled += RecentProductWidget_AfterInstalled;
        }

        #region Events

        void RecentProductWidget_BeforeInstalled(object sender, EventArgs e)
        {
        }

        void RecentProductWidget_AfterInstalled(IWidget sender, WidgetEventArgs e)
        {
        }

        #endregion

        protected override RecentProductsModel InitializeModel()
        {
            int pageSize = base.GetPropertyValue<int>(WidgetBaseConstants.PropertyDefaultPageSize);
            var listProducts = DomainRepositories.ContentItem.GetByContentType(typeof(Product), pageSize);

            RecentProductsModel model = new RecentProductsModel(base.region);
            model.InitializeProducts(listProducts);

            return model;
        }
    }
}