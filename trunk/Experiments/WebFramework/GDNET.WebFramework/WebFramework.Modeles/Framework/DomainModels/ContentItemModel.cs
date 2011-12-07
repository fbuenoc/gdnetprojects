using WebFrameworkDomain.Common;
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
            this.ContentType = (entity.ContentType == null || entity.ContentType.Name == null) ? string.Empty : entity.ContentType.Name.Value;
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
