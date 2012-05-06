using GDNET.Common.Base.Entities;
using WebFramework.Domain.Base;
using WebFramework.Domain.Common;

namespace WebFramework.Widgets.ArticleWg.Domain
{
    public partial class Article : EntityBase<long>, IEntityWithLifeCycle
    {
        public virtual string Title
        {
            get;
            set;
        }

        public virtual string Description
        {
            get;
            set;
        }

        public virtual string FullContent
        {
            get;
            set;
        }

        #region IEntityLifeCycle

        public virtual StatutLifeCycle LifeCycle
        {
            get;
            protected internal set;
        }

        public virtual void ApplyDefaultSettings()
        {
        }

        #endregion

        #region Ctors

        protected Article()
        {
            this.LifeCycle = StatutLifeCycle.Factory.Create();
            this.ApplyDefaultSettings();
        }

        #endregion
    }
}