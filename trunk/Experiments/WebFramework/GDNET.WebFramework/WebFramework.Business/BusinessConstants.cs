using GDNET.Common.Helpers;
using WebFramework.Business.Common;

namespace WebFramework.Business
{
    public sealed class BusinessConstants
    {
        public sealed class ProductConstants
        {
            private static readonly Product defaultProduct = Product.Factory.NewInstance();

            public static readonly string Price = ExpressionAssistant.GetPropertyName(() => defaultProduct.Price);
            public static readonly string Discount = ExpressionAssistant.GetPropertyName(() => defaultProduct.Discount);
            public static readonly string RealPrice = ExpressionAssistant.GetPropertyName(() => defaultProduct.RealPrice);
            public static readonly string IntroDate = ExpressionAssistant.GetPropertyName(() => defaultProduct.IntroDate);
            public static readonly string InStock = ExpressionAssistant.GetPropertyName(() => defaultProduct.InStock);
        }
    }
}
