using System.Collections.Generic;
using System.Linq;
using WebFramework.Base.Framework.Base;
using WebFrameworkDomain.Common;
using WebFrameworkServices.ComponentModel;

namespace WebFramework.Base.Framework.Common
{
    public class ContentItemModel : ModelWithModificationBase<ContentItem, long>
    {
        #region Properties

        [DisplayNameML("ApplicationCategories.SysTranslation.EntityNames.ContentType")]
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

        [RequiredML(ErrorCode = "ApplicationCategories.SysTranslation.ContentItem.NameIsRequired")]
        [DisplayNameML("ApplicationCategories.SysTranslation.Name")]
        public string Name
        {
            get;
            set;
        }

        [DisplayNameML("ApplicationCategories.SysTranslation.Description")]
        public string Description
        {
            get;
            set;
        }

        [DisplayNameML("ApplicationCategories.SysTranslation.Position")]
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
            get;
            protected set;
        }

        #endregion

        #region Ctors

        public ContentItemModel() : base() { }

        public ContentItemModel(ContentItem entity)
            : base(entity)
        {
            this.ContentType = entity.ContentType.Name.Value;
            this.ContentTypeId = entity.ContentType.Id;

            this.ContentTypeModel = new ContentTypeModel(entity.ContentType);

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

        public ContentAttributeModel GetAttribute(string attributeCode)
        {
            return this.Attributes.FirstOrDefault(x => x.Code == attributeCode);
        }

        #endregion

    }
}
