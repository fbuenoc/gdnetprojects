﻿using GDNET.Domain.Base.Exceptions;

namespace GDNET.Domain.Content
{
    public partial class ContentItem
    {
        public static ContentItemFactory Factory
        {
            get { return new ContentItemFactory(); }
        }

        public class ContentItemFactory
        {
            public ContentItem Create(string name, bool isActive)
            {
                ExceptionsManager.BusinessException.ThrowIfIsNullOrWhiteSpace(name);

                return new ContentItem
                {
                    Name = name,
                    IsActive = isActive
                };
            }
        }
    }
}
