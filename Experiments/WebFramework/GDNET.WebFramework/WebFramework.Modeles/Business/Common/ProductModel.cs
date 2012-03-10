using System;
using WebFramework.Base.Business.Base;
using WebFrameworkBusiness.Common;

namespace WebFramework.Base.Business.Common
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
