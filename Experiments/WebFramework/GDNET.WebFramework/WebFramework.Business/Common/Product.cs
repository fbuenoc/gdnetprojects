using System;
using WebFramework.Business.Base;

namespace WebFramework.Business.Common
{
    public sealed partial class Product : BusinessEntityBase, IBusinessEntity
    {
        #region Properties

        public decimal Price
        {
            get { return this.GetValue<decimal>(() => this.Price); }
            set
            {
                this.SetValue<decimal>(() => this.Price, value);
                this.UpdateRealPrice();
            }
        }

        public decimal Discount
        {
            get { return this.GetValue<decimal>(() => this.Discount); }
            set
            {
                this.SetValue<decimal>(() => this.Discount, value);
                this.UpdateRealPrice();
            }
        }

        public decimal RealPrice
        {
            get { return this.GetValue<decimal>(() => this.RealPrice); }
            protected set { this.SetValue<decimal>(() => this.RealPrice, value); }
        }

        public DateTime IntroDate
        {
            get { return this.GetValue<DateTime>(() => this.IntroDate); }
            set { this.SetValue<DateTime>(() => this.IntroDate, value); }
        }

        public bool InStock
        {
            get { return this.GetValue<bool>(() => this.InStock); }
            set { this.SetValue<bool>(() => this.InStock, value); }
        }

        #endregion

        #region Behaviors

        private void UpdateRealPrice()
        {
            decimal realPrice = this.Price - this.Discount;
            if (realPrice < 0) { realPrice = 0; }
            this.RealPrice = realPrice;
        }

        #endregion
    }
}
