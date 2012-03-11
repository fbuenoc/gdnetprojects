using WebFramework.Base.Business.Base;
using WebFramework.Base.ComponentModel;
using WebFramework.Business.Administration;

namespace WebFramework.Base.Business.Administration
{
    public sealed class ShortcutModel : ModelBusinessEntityBase<Shortcut>
    {
        [DisplayNameML("ApplicationCategories.TargetUrlTranslation.Description")]
        public string TargetUrl
        {
            get;
            set;
        }

        #region Ctors

        public ShortcutModel() : base() { }

        public ShortcutModel(Shortcut entity)
            : base(entity)
        {
            this.TargetUrl = entity.TargetUrl;
        }

        #endregion
    }
}
