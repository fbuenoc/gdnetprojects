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

        public DateTime IntroDate
        {
            get { return this.GetValue<DateTime>(() => this.IntroDate); }
            set { this.SetValue<DateTime>(() => this.IntroDate, value); }
        }

        public string MainContent
        {
            get { return this.GetValue<string>(() => this.MainContent); }
            set { this.SetValue<string>(() => this.MainContent, value); }
        }

        #endregion

        protected Product()
            : base(EncryptionOption.Base64)
        {
        }
    }
}
