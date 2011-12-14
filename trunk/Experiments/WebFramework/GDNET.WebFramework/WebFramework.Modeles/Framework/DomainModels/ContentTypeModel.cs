using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

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
            get
            {
                List<ContentAttributeModel> listOfAttributes = new List<ContentAttributeModel>();
                if (base.Entity != null)
                {
                    listOfAttributes.AddRange(base.Entity.ContentAttributes.Select(x => new ContentAttributeModel(x)));
                }

                return listOfAttributes;
            }
        }

        #endregion
    }
}
