using GDNET.Common.DesignByContract;

namespace WebFramework.Domain.Common
{
    public partial class ContentItemAttributeValue
    {
        public static ContentItemAttributeValueFactory Factory
        {
            get { return new ContentItemAttributeValueFactory(); }
        }

        public class ContentItemAttributeValueFactory
        {
            public ContentItemAttributeValue Create(ContentAttribute attribute, string value)
            {
                ThrowException.ArgumentNullException(attribute, "attribute", "Content attribute can not be nullable.");

                if (attribute.IsMultilingual)
                {
                    var translation = Translation.Factory.Create(value);
                    return this.Create(attribute, translation);
                }
                else
                {
                    var itemAttributeValue = new ContentItemAttributeValue()
                    {
                        ContentAttribute = attribute,
                    };
                    itemAttributeValue.SetValueText(value);

                    return itemAttributeValue;
                }
            }

            public ContentItemAttributeValue Create(ContentAttribute attribute, Translation value)
            {
                ThrowException.ArgumentNullException(attribute, "attribute", "Content attribute can not be nullable.");
                ThrowException.ArgumentNullException(value, "value", "Value can not be nullable.");

                var itemAttributeValue = new ContentItemAttributeValue()
                {
                    ContentAttribute = attribute,
                };
                itemAttributeValue.SetValueTranslation(value);

                return itemAttributeValue;
            }

        }
    }
}
