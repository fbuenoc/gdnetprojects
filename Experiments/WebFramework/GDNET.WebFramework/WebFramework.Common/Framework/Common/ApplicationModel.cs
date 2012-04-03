using System.ComponentModel.DataAnnotations;
using WebFramework.Common.ComponentModel;
using WebFramework.Common.Framework.Base;
using WebFramework.Domain.Common;

namespace WebFramework.Common.Framework.Common
{
    public sealed class ApplicationModel : ModelWithLifeCycleBase<Application, long>
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
            this.Category = (base.Entity.Category == null || base.Entity.Category.Description == null) ? string.Empty : base.Entity.Category.Description.Value;
            this.RootUrl = (base.Entity.RootUrl == "*") ? string.Empty : base.Entity.RootUrl;
        }

        #endregion
    }
}
