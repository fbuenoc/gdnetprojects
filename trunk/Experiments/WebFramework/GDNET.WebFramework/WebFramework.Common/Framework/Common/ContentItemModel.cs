using System;
using System.Collections.Generic;
using System.Linq;
using WebFramework.Common.ComponentModel;
using WebFramework.Common.Framework.Base;
using WebFramework.Domain.Common;

namespace WebFramework.Common.Framework.Common
{
    public class ContentItemModel : AbstractModelWithModification<ContentItem, long>
    {
        private List<ContentAttributeModel> listAttributes = new List<ContentAttributeModel>();

        #region Properties

        [DisplayNameML("SysTranslation.EntityNames.ContentType")]
        public string ContentType
        {
            get;
            protected set;
        }

        public long ContentTypeId
        {
            get;
            set;
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

        public IEnumerable<ContentAttributeModel> Attributes
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

        public IEnumerable<ContentItemAttributeValueModel> AttributesValue
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

        public IEnumerable<ContentItemModel> RelatedItems
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

        public ContentTypeModel ContentTypeModel
        {
            get
            {
                return (base.Entity == null) ? null : new ContentTypeModel(base.Entity.ContentType);
            }
        }

        #endregion

        #region Ctors

        public ContentItemModel() : base() { }

        public ContentItemModel(ContentItem entity)
            : base(entity)
        {
            this.ContentType = entity.ContentType.Name.Value;
            this.ContentTypeId = entity.ContentType.Id;

            this.Name = (entity.Name == null) ? string.Empty : entity.Name.Value;
            this.Description = (entity.Description == null) ? string.Empty : entity.Description.Value;
            this.Position = entity.Position;
        }

        #endregion

        #region Behaviors

        public void InitializeContentType(ContentTypeModel typeModel)
        {
            this.ContentType = typeModel.Name;
            this.ContentTypeId = typeModel.Id;

            this.listAttributes.Clear();
            this.listAttributes.AddRange(typeModel.Attributes);
        }

        public T GetAttribute<T>(string attributeCode)
        {
            ContentItemAttributeValueModel valueModel = this.AttributesValue.FirstOrDefault(x => x.AttributeModel.Code == attributeCode);
            if (valueModel != null)
            {
                return (T)Convert.ChangeType(valueModel.Value, typeof(T));
            }
            return default(T);
        }

        #endregion

    }
}
