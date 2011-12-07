using WebFrameworkDomain.Common;
using WebFramework.Modeles.Framework.Common;

namespace WebFramework.Modeles.Framework.DomainModels
{
    public sealed class ContentTypeModel : ModelFullControlBase<ContentType, long>
    {
        #region Ctors

        public ContentTypeModel() : base() { }

        public ContentTypeModel(ContentType entity)
            : base(entity)
        {
            this.Name = (entity.Name == null) ? string.Empty : entity.Name.Value;
            this.TypeName = entity.TypeName;

            if (entity.Application != null)
            {
                if (entity.Application.Name != null)
                {
                    this.Application = entity.Application.Name.Value;
                }
                this.ApplicationId = entity.Application.Id;
            }
        }

        #endregion

        #region Properties

        public string Name
        {
            get;
            set;
        }

        public string TypeName
        {
            get;
            set;
        }

        public string Application
        {
            get;
            set;
        }

        public long ApplicationId
        {
            get;
            set;
        }

        #endregion
    }
}
