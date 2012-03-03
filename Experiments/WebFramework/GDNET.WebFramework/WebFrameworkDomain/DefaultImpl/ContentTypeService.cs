using System.Collections.Generic;
using WebFrameworkDomain.Common;
using WebFrameworkDomain.Services;

namespace WebFrameworkDomain.DefaultImpl
{
    public class ContentTypeService : IContentTypeService
    {
        public Dictionary<string, ListValue> GetAttributesInformation(ContentType contentType)
        {
            Dictionary<string, ListValue> attributesInfo = new Dictionary<string, ListValue>();

            foreach (var attribute in contentType.ContentAttributes)
            {
                attributesInfo.Add(attribute.Code, attribute.DataType);
            }

            return attributesInfo;
        }

        public void BuildAttributesValue(ContentType contentType, ContentItem contentItem, Dictionary<string, string> formValues)
        {
            foreach (var contentAttribute in contentType.ContentAttributes)
            {
                if (formValues.ContainsKey(contentAttribute.Code))
                {
                    var attributeValue = ContentItemAttributeValue.Factory.Create(contentAttribute, formValues[contentAttribute.Code]);
                    contentItem.AddAttributeValue(attributeValue);
                }
            }
        }
    }
}
