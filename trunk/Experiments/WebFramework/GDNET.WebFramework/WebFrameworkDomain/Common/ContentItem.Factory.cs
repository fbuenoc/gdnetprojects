using GDNET.Common.Base.Entities;
using GDNET.Common.DesignByContract;
using System;

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

            public ContentItem Create(string name, string description)
            {
                return this.Create(name, description);
            }

            public ContentItem Create(string name, string description, int position)
            {
                Throw.ArgumentExceptionIfNullOrEmpty(name, "name", "Name of content item can not be nullable.");

                var contentItem = this.Create();

                contentItem.Name = Translation.Factory.Create(Guid.NewGuid().ToString(), name);
                contentItem.Description = Translation.Factory.Create(Guid.NewGuid().ToString(), description);
                contentItem.Position = position;

                return contentItem;
            }
        }
    }
}
