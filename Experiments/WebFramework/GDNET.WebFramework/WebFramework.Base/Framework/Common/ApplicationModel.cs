using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using WebFramework.Base.Framework.Base;
using WebFramework.Domain.Common;

namespace WebFramework.Base.Framework.Common
{
    public sealed class ApplicationModel : ModelWithModificationBase<Application, long>
    {
        #region Properties

        [Required]
        [DisplayName("SysTranslation.Name")]
        public string Name
        {
            get;
            set;
        }

        [DisplayName("SysTranslation.Description")]
        public string Description
        {
            get;
            set;
        }

        [DisplayName("SysTranslation.Category")]
        public string Category
        {
            get;
            set;
        }

        [Required]
        [DisplayName("SysTranslation.Application.RootUrl")]
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
            this.RootUrl = base.Entity.RootUrl.StartsWith("http://") ? base.Entity.RootUrl : string.Format("http://{0}", base.Entity.RootUrl);
        }

        #endregion
    }
}
