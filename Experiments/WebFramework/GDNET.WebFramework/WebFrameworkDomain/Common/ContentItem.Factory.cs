using System;

using GDNET.Common.Base.Entities;
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
            public ContentItem Create()
            {
                return new ContentItem
                {
                    IsActive = true,
                    IsEditable = true,
                    IsDeletable = true,
                    IsViewable = true,
                };
            }

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
                Throw.ArgumentNullException(type, "type", "Type of content item can not be null.");
                Throw.ArgumentExceptionIfNullOrEmpty(name, "name", "Name of content item can not be null.");

                var contentItem = this.Create();

                contentItem.ContentType = type;
                contentItem.Name = Translation.Factory.Create(name);
                contentItem.Description = Translation.Factory.Create(description);
                contentItem.Position = position;

                return contentItem;
            }
        }
    }
}
