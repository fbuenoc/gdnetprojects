﻿using System;
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

            public ContentType Create(string name)
            {
                return this.Create(name, string.Empty);
            }

            public ContentType Create(string name, string typeName)
            {
                return this.Create(name, typeName, Guid.NewGuid().ToString().Replace("-", string.Empty));
            }

            public ContentType Create(string name, string typeName, string code)
            {
                ThrowException.ArgumentExceptionIfNullOrEmpty(name, "name", "Name of content type can not be nullable.");
                ThrowException.ArgumentExceptionIfNullOrEmpty(code, "code", "Code of content type can not be nullable.");

                var contentType = this.Create();

                contentType.Name = Translation.Factory.Create(name);
                contentType.TypeName = typeName;
                contentType.Code = code;
                contentType.Application = null;

                return contentType;
            }
        }
    }
}