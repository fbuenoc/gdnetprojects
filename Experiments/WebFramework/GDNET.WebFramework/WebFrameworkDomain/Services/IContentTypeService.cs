using System.Collections.Generic;
using WebFrameworkDomain.Common;

namespace WebFrameworkDomain.Services
{
    public interface IContentTypeService
    {
        Dictionary<string, ListValue> GetAttributesInformation(ContentType contentType);
        void BuildAttributesValue(ContentType contentType, ContentItem contentItem, Dictionary<string, string> formValues);
    }
}
