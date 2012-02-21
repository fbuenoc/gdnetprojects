using GDNET.Common.Base.Entities;
using WebFrameworkDomain.Base;
using WebFrameworkDomain.Extensions;

namespace WebFrameworkDomain.Common
{
    public partial class Translation : EntityWithModificationBase<long>, IEntityWithLifeCycle
    {
        #region Properties

        public virtual ListValue Category
        {
            get;
            set;
        }

        public virtual Culture Culture
        {
            get;
            set;
        }

        public virtual string Code
        {
            get;
            set;
        }

        public virtual string Value
        {
            get;
            set;
        }

        #endregion

        #region IEntityLifeCycle

        public virtual StatutLifeCycle LifeCycle
        {
            get;
            private set;
        }

        public void ApplyDefaultSettings()
        {
            EntityAssistant.ChangeActive(this, true);
            EntityAssistant.ChangeDeletable(this, true);
            EntityAssistant.ChangeEditable(this, true);
        }

        #endregion

        protected Translation()
        {
            this.LifeCycle = StatutLifeCycle.Factory.Create();
            this.ApplyDefaultSettings();
        }
    }
}
