﻿using GDNET.Common.DesignByContract;

namespace WebFrameworkDomain.Common
{
    public partial class ContentItemAttributeValue
    {
        public static ContentItemAttributeValueFactory Factory
        {
            get { return new ContentItemAttributeValueFactory(); }
        }

        public class ContentItemAttributeValueFactory
        {
            public ContentItemAttributeValue Create(ContentAttribute attribute, ContentItem item, string value)
            {
                var translation = Translation.Factory.Create(value);
                return this.Create(attribute, item, translation);
            }

            public ContentItemAttributeValue Create(ContentAttribute attribute, ContentItem item, Translation value)
            {
                ThrowException.ArgumentNullException(attribute, "attribute", "Content attribute can not be nullable.");
                ThrowException.ArgumentNullException(item, "item", "Content item can not be nullable.");
                ThrowException.ArgumentNullException(value, "value", "Value can not be nullable.");

                var itemAttributeValue = new ContentItemAttributeValue { };

                itemAttributeValue.ContentAttribute = attribute;
                itemAttributeValue.ContentItem = item;
                itemAttributeValue.Value = value;

                return itemAttributeValue;
            }

        }
    }
}