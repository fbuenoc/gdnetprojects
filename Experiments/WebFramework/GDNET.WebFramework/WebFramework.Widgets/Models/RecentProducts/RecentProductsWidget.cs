using System;
using WebFramework.Business.Common;
using WebFramework.Common.Widgets;
using WebFramework.Domain;
using WebFramework.Domain.Constants;

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
            base.RegisterProperty(WidgetBaseConstants.PropertyPageSize, WidgetBaseConstants.DefaultPageSize.ToString(), ListValueConstants.ContentDataTypes.NumberNormalNumber);
        }

        protected override RecentProductsModel InitializeModel()
        {
            int pageSize = base.GetPropertyValue<int>(WidgetBaseConstants.PropertyPageSize);
            var listProducts = DomainRepositories.ContentItem.GetByContentType(typeof(Product), pageSize);

            RecentProductsModel model = new RecentProductsModel(base.region);
            model.InitializeProducts(listProducts);

            return model;
        }
    }
}