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
            get;
            protected set;
        }

        public IEnumerable<ContentItemAttributeValueModel> AttributesValue
        {
            get;
            protected set;
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

            this.AttributesValue = entity.AttributeValues.Select(x => new ContentItemAttributeValueModel(x));
        }

        #endregion

        #region Behaviors

        public void InitializeContentType(ContentTypeModel typeModel)
        {
            this.ContentType = typeModel.Name;
            this.ContentTypeId = typeModel.Id;
            this.Attributes = typeModel.Attributes;
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
