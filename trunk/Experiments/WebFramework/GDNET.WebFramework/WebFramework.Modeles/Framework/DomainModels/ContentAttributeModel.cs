using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

using WebFrameworkDomain.Common;
using WebFramework.Modeles.Framework.Common;

namespace WebFramework.Modeles.Framework.DomainModels
{
    public class ContentAttributeModel : ModelFullControlBase<ContentAttribute, long>
    {
        #region Ctors

        public ContentAttributeModel() : base() { }

        public ContentAttributeModel(ContentAttribute entity)
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

            if (entity.DataType != null)
            {
                if (entity.DataType.Description != null)
                {
                    this.DataType = entity.DataType.Description.Value;
                }
                this.DataTypeId = entity.DataType.Id;
            }

            this.Code = entity.Code;
            this.Position = entity.Position;
        }

        #endregion

        #region Properties

        public string ContentType
        {
            get;
            set;
        }

        public long ContentTypeId
        {
            get;
            set;
        }

        public string DataType
        {
            get;
            set;
        }

        [DisplayName("Data type")]
        public long DataTypeId
        {
            get;
            set;
        }

        [Required]
        [DisplayName("Name")]
        public string Code
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
