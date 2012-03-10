using WebFramework.Business.Base;

namespace WebFramework.Business.Common
{
    public sealed partial class Product : BusinessEntityBase, IBusinessEntity
    {
        public static ProductFactory Factory
        {
            get { return new ProductFactory(); }
        }

        public class ProductFactory
        {
            public Product NewInstance()
            {
                return BusinessEntityBase.Factory.NewInstance<Product>();
            }

            public Product Create(string name, string description, decimal price)
            {
                var p = BusinessEntityBase.Factory.Create<Product>(name, description);
                p.Price = price;

                return p;
            }
        }
    }
}
