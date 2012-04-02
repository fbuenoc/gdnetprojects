using System.ComponentModel;
using WebFramework.Common.Framework.Base;
using WebFramework.Domain.Common;

namespace WebFramework.Common.Framework.Common
{
    public class ContentItemAttributeValueModel : ModelBase<ContentItemAttributeValue, long>
    {
        #region Properties

        public string ContentItemName
        {
            get;
            protected set;
        }

        public ContentItemModel ContentItem
        {
            get
            {
                if (base.Entity != null)
                {
                    return new ContentItemModel(base.Entity.ContentItem);
                }

                return default(ContentItemModel);
            }
        }

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

        public ContentAttributeModel ContentAttribute
        {
            get
            {
                if (base.Entity != null)
                {
                    return new ContentAttributeModel(base.Entity.ContentAttribute);
                }
                return default(ContentAttributeModel);
            }
        }

        #endregion

        #region Ctors

        public ContentItemAttributeValueModel() : base() { }

        public ContentItemAttributeValueModel(ContentItemAttributeValue entity)
            : base(entity)
        {
            this.ContentItemName = entity.ContentItem.Name.Value;
            this.Value = entity.Value.Value;
            this.DataTypeName = entity.ContentAttribute.DataType.Name;
        }

        #endregion
    }
}
