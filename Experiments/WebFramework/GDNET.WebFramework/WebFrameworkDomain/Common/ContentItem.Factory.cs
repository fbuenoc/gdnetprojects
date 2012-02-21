using GDNET.Common.DesignByContract;
using WebFrameworkDomain.DefaultImpl;

namespace WebFrameworkDomain.Common
{
    public partial class ContentItem
    {
        public static ContentItemFactory Factory
        {
            get { return new ContentItemFactory(); }
        }

        public class ContentItemFactory
        {
            public ContentItem Create(string name, string description, ContentType type)
            {
                return this.Create(name, description, type, 0);
            }

            public ContentItem Create(string name, string description, long contentTypeId, int position)
            {
                var contentType = DomainRepositories.ContentType.GetById(contentTypeId);
                return this.Create(name, description, contentType, position);
            }

            public ContentItem Create(string name, string description, ContentType type, int position)
            {
                ThrowException.ArgumentNullException(type, "type", "Type of content item can not be null.");
                ThrowException.ArgumentExceptionIfNullOrEmpty(name, "name", "Name of content item can not be null.");

                var contentItem = new ContentItem
                {
                    ContentType = type,
                    Position = position
                };

                contentItem.Name = Translation.Factory.Create(name);
                contentItem.Description = Translation.Factory.Create(description);

                return contentItem;
            }
        }
    }
}
