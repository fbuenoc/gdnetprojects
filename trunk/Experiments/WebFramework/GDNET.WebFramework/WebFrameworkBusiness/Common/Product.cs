using System;
using GDNET.Common.Security.Services;
using WebFrameworkBusiness.Base;

namespace WebFrameworkBusiness.Common
{
    public sealed partial class Product : BusinessEntityBase, IBusinessEntity
    {
        #region Properties

        public decimal Price
        {
            get { return this.GetValue<decimal>(() => this.Price); }
            set { this.SetValue<decimal>(() => this.Price, value); }
        }

        public decimal Discount
        {
            get { return this.GetValue<decimal>(() => this.Discount); }
            set { this.SetValue<decimal>(() => this.Discount, value); }
        }

        public DateTime IntroDate
        {
            get { return this.GetValue<DateTime>(() => this.IntroDate); }
            set { this.SetValue<DateTime>(() => this.IntroDate, value); }
        }

        #endregion

        protected Product()
            : base(EncryptionOption.Base64)
        {
        }
    }
}
