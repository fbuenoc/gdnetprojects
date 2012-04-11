using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using WebFramework.Common.Framework.Base;
using WebFramework.Domain.Common;

namespace WebFramework.Common.Framework.Common
{
    public sealed class ContentTypeModel : ModelWithLifeCycleBase<ContentType, long>
    {
        #region Properties

        [Required]
        [DisplayName("Name of content type")]
        public string Name
        {
            get;
            set;
        }

        [DisplayName("Code of content type")]
        public string Code
        {
            get;
            set;
        }

        [DisplayName("Technical type name")]
        public string TypeName
        {
            get;
            set;
        }

        [DisplayName("Application")]
        public string Application
        {
            get;
            set;
        }

        [DisplayName("Application ID")]
        public long ApplicationId
        {
            get;
            set;
        }

        public IList<ContentAttributeModel> Attributes
        {
            get
            {
                List<ContentAttributeModel> attributesModel = new List<ContentAttributeModel>();
                if (base.Entity != null)
                {
                    attributesModel.AddRange(base.Entity.ContentAttributes.OrderBy(x => x.Position).Select(x => new ContentAttributeModel(x)));
                }
                return attributesModel;
            }
        }

        #endregion

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

    }
}
