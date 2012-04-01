using System.ComponentModel;
using WebFramework.Common.Framework.Base;
using WebFramework.Domain.Common;

namespace WebFramework.Common.Framework.Common
{
    public class ContentItemAttributeValueModel : AbstractModelGeneric<ContentItemAttributeValue, long>
    {
        #region Properties

        public string ContentAttributeName
        {
            get;
            protected set;
        }

        public long ContentAttributeId
        {
            get;
            protected set;
        }

        public string ContentItemName
        {
            get;
            protected set;
        }

        [DisplayName("Data type")]
        public long ContentItemId
        {
            get;
            protected set;
        }

        [DisplayName("")]
        public string Value
        {
            get;
            protected set;
        }

        public string DataTypeName
        {
            get;
            protected set;
        }

        public ContentAttributeModel AttributeModel
        {
            get;
            protected set;
        }

        #endregion

        #region Ctors

        public ContentItemAttributeValueModel() : base() { }

        public ContentItemAttributeValueModel(ContentItemAttributeValue entity)
            : base(entity)
        {
            this.ContentAttributeId = entity.ContentAttribute.Id;
            this.ContentAttributeName = entity.ContentAttribute.Name.Value;
            this.ContentItemId = entity.ContentItem.Id;
            this.ContentItemName = entity.ContentItem.Name.Value;
            this.Value = entity.Value.Value;
            this.DataTypeName = entity.ContentAttribute.DataType.Name;

            this.AttributeModel = new ContentAttributeModel(entity.ContentAttribute);
        }

        #endregion
    }
}
