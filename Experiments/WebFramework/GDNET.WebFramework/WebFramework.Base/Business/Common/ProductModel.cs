using System;
using WebFramework.Common.Business.Base;
using WebFramework.Business.Common;

namespace WebFramework.Common.Business.Common
{
    public sealed class ProductModel : ModelBusinessEntityBase<Product>
    {
        public decimal Price
        {
            get;
            set;
        }

        public decimal Discount
        {
            get;
            set;
        }

        public DateTime IntroDate
        {
            get;
            set;
        }

        #region Ctors

        public ProductModel() : base() { }

        public ProductModel(Product entity)
            : base(entity)
        {
        }

        #endregion
    }
}
