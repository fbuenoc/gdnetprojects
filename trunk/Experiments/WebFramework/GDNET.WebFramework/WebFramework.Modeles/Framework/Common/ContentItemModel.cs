using System.Collections.Generic;
using System.Linq;
using WebFramework.Modeles.Framework.Base;
using WebFrameworkDomain.Common;
using WebFrameworkServices.ComponentModel;

namespace WebFramework.Modeles.Framework.Common
{
    public sealed class ContentItemModel : ModelWithModificationBase<ContentItem, long>
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

        #endregion

        public void InitializeContentType(ContentTypeModel typeModel)
        {
            this.ContentType = typeModel.Name;
            this.ContentTypeId = typeModel.Id;
            this.Attributes = typeModel.Attributes;
        }

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

            this.AttributesValue = entity.AttributeValues.Select(x => new ContentItemAttributeValueModel(x));
        }

        #endregion

    }
}
