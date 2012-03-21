using System.ComponentModel.DataAnnotations;
using WebFramework.Base.ComponentModel;
using WebFramework.Base.Framework.Base;
using WebFramework.Domain.Common;

namespace WebFramework.Base.Framework.Common
{
    public sealed class ApplicationModel : AbstractModelWithModification<Application, long>
    {
        #region Properties

        [Required]
        [DisplayNameML("SysTranslation.Name")]
        public string Name
        {
            get;
            set;
        }

        [DisplayNameML("SysTranslation.Description")]
        public string Description
        {
            get;
            set;
        }

        [DisplayNameML("SysTranslation.Category")]
        public string Category
        {
            get;
            set;
        }

        [Required]
        [DisplayNameML("SysTranslation.Application.RootUrl")]
        public string RootUrl
        {
            get;
            set;
        }

        #endregion

        #region Ctors

        public ApplicationModel()
            : base()
        { }

        public ApplicationModel(Application application)
            : base(application)
        {
            this.Name = (base.Entity.Name == null) ? string.Empty : base.Entity.Name.Value;
            this.Description = (base.Entity.Description == null) ? string.Empty : base.Entity.Description.Value;
            this.Category = (base.Entity.Category.Description == null) ? string.Empty : base.Entity.Category.Description.Value;
            this.RootUrl = (base.Entity.RootUrl == "*") ? string.Empty : base.Entity.RootUrl;
        }

        #endregion
    }
}
