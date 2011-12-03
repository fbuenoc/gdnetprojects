﻿using System;

using GDNET.Common.Base.Entities;
using GDNET.Common.DesignByContract;

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
            public ContentItemAttributeValue Create()
            {
                return new ContentItemAttributeValue { };
            }

            public ContentItemAttributeValue Create(ContentAttribute attribute, ContentItem item, Translation value)
            {
                Throw.ArgumentNullException(attribute, "attribute", "Content attribute can not be nullable.");
                Throw.ArgumentNullException(item, "item", "Content item can not be nullable.");
                Throw.ArgumentNullException(value, "value", "Value can not be nullable.");

                var itemAttributeValue = this.Create();

                itemAttributeValue.ContentAttribute = attribute;
                itemAttributeValue.ContentItem = item;
                itemAttributeValue.Value = value;

                return itemAttributeValue;
            }

            public ContentItemAttributeValue Create(ContentAttribute attribute, ContentItem item, string value)
            {
                var translation = Translation.Factory.Create(Guid.NewGuid().ToString(), value);
                return this.Create(attribute, item, translation);
            }
        }
    }
}