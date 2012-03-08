using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using WebFramework.Models.Framework.Base;
using WebFrameworkDomain.Common;

namespace WebFramework.Models.Framework.Common
{
    public sealed class ContentTypeModel : ModelWithModificationBase<ContentType, long>
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

        public IEnumerable<ContentAttributeModel> Attributes
        {
            get;
            private set;
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

            this.Attributes = entity.ContentAttributes.OrderBy(x => x.Position).Select(x => new ContentAttributeModel(x));
        }

        #endregion

    }
}
