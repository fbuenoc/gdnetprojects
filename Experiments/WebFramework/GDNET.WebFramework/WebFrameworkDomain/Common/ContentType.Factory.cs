using System;
using GDNET.Common.Base.Entities;
using GDNET.Common.DesignByContract;

namespace WebFrameworkDomain.Common
{
    public partial class ContentType
    {
        public static ContentTypeFactory Factory
        {
            get { return new ContentTypeFactory(); }
        }

        public sealed class ContentTypeFactory
        {
            public ContentType Create()
            {
                return new ContentType
                {
                    IsActive = true,
                    IsEditable = true,
                    IsDeletable = true,
                    IsViewable = true,
                };
            }

            public ContentType Create(string name, string typeName)
            {
                Throw.ArgumentExceptionIfNullOrEmpty(name, "name", "Name of content item can not be nullable.");
                Throw.ArgumentExceptionIfNullOrEmpty(typeName, "typeName", "Type name of content item can not be nullable.");

                var contentItem = this.Create();

                contentItem.Name = Translation.Factory.Create(Guid.NewGuid().ToString(), name);
                contentItem.TypeName = typeName;

                return contentItem;
            }
        }
    }
}
