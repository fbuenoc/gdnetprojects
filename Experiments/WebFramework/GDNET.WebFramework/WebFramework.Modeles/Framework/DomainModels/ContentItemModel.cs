﻿using WebFrameworkDomain.Common;
using WebFramework.Modeles.Framework.Common;

namespace WebFramework.Modeles.Framework.DomainModels
{
    public sealed class ContentItemModel : ModelFullControlBase<ContentItem, long>
    {
        #region Ctors

        public ContentItemModel() : base() { }

        public ContentItemModel(ContentItem entity)
            : base(entity)
        {
            if (entity.ContentType != null)
            {
                if (entity.ContentType.Name != null)
                {
                    this.ContentType = entity.ContentType.Name.Value;
                }
                this.ContentTypeId = entity.ContentType.Id;
            }

            this.Name = (entity.Name == null) ? string.Empty : entity.Name.Value;
            this.Description = (entity.Description == null) ? string.Empty : entity.Description.Value;
            this.Position = entity.Position;
        }

        #endregion

        #region Properties

        public string ContentType
        {
            get;
            set;
        }

        public long ContentTypeId
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public string Description
        {
            get;
            set;
        }

        public int Position
        {
            get;
            set;
        }

        #endregion

    }
}