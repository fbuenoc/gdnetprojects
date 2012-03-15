using System.Collections.Generic;
using WebFramework.Domain.Common;

namespace WebFramework.Domain.Services
{
    public interface IContentTypeService
    {
        Dictionary<string, ListValue> GetAttributesInformation(ContentType contentType);
        void BuildAttributesValue(ContentType contentType, ContentItem contentItem, Dictionary<string, string> formValues);
    }
}
