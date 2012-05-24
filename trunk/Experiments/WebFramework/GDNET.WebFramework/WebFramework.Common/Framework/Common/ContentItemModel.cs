using System;
using System.Collections.Generic;
using System.Linq;
using WebFramework.Common.ComponentModel;
using WebFramework.Common.Framework.Base;
using WebFramework.Domain.Common;

namespace WebFramework.Common.Framework.Common
{
    public class ContentItemModel : ModelEntityWithLifeCycleBase<ContentItem, long>
    {
        private List<ContentAttributeModel> listAttributes = new List<ContentAttributeModel>();
        private ContentTypeModel contentType = default(ContentTypeModel);

        #region Properties

        [DisplayNameML("SysTranslation.EntityNames.ContentType")]
        public ContentTypeModel ContentType
        {
            get
            {
                if (base.Entity != null && base.Entity.ContentType != null)
                {
                    this.InitializeContentType(base.Entity.ContentType);
                }
                return contentType;
            }
        }

        [RequiredML(ErrorCode = "SysTranslation.ContentItem.NameIsRequired")]
        [DisplayNameML("SysTranslation.Name")]
        public string Name
        {
            get;
            set;
        }

        [DisplayNameML("SysTranslation.Description")]
        public string Description
        {
            get;
            set;
        }

        [DisplayNameML("SysTranslation.Position")]
        public int Position
        {
            get;
            set;
        }

        public IList<ContentAttributeModel> Attributes
        {
            get
            {
                if (base.Entity != null)
                {
                    this.listAttributes.AddRange(base.Entity.AttributeValues.Select(x => new ContentAttributeModel(x.ContentAttribute)));
                }
                return this.listAttributes;
            }
        }

        public IList<ContentItemAttributeValueModel> AttributesValue
        {
            get
            {
                List<ContentItemAttributeValueModel> listAttributes = new List<ContentItemAttributeValueModel>();
                if (base.Entity != null)
                {
                    listAttributes.AddRange(base.Entity.AttributeValues.Select(x => new ContentItemAttributeValueModel(x)));
                }
                return listAttributes;
            }
        }

        public IList<ContentItemModel> RelatedItems
        {
            get
            {
                List<ContentItemModel> listItems = new List<ContentItemModel>();
                if (base.Entity != null)
                {
                    listItems.AddRange(base.Entity.RelationItems.Select(x => new ContentItemModel(x)));
                }
                return listItems;
            }
        }

        #endregion

        #region Ctors

        public ContentItemModel() : base() { }

        public ContentItemModel(ContentItem entity)
            : base(entity)
        {
            this.Name = (entity.Name == null) ? string.Empty : entity.Name.Value;
            this.Description = (entity.Description == null) ? string.Empty : entity.Description.Value;
            this.Position = entity.Position;
        }

        #endregion

        #region Behaviors

        public ContentItemModel InitializeContentType(ContentType contentType)
        {
            this.contentType = new ContentTypeModel(contentType);
            return this;
        }

        public T GetAttribute<T>(string attributeCode)
        {
            ContentItemAttributeValueModel valueModel = this.AttributesValue.FirstOrDefault(x => x.ContentAttribute.Code == attributeCode);
            if ((valueModel != null) && !string.IsNullOrEmpty(valueModel.Value))
            {
                return (T)Convert.ChangeType(valueModel.Value, typeof(T));
            }
            return default(T);
        }

        #endregion

    }
}
