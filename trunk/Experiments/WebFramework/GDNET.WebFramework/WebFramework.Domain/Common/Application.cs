using System.Collections.Generic;
using System.Collections.ObjectModel;
using GDNET.Common.Base.Entities;
using WebFramework.Domain.Base;
using WebFramework.Domain.Extensions;

namespace WebFramework.Domain.Common
{
    public partial class Application : EntityWithModificationBase<long>, IEntityWithLifeCycle
    {
        private IList<ContentType> contentTypes = new List<ContentType>();

        #region Properties

        public virtual Translation Name
        {
            get;
            set;
        }

        public virtual Translation Description
        {
            get;
            set;
        }

        public virtual ListValue Category
        {
            get;
            set;
        }

        public virtual Culture CultureDefault
        {
            get;
            set;
        }

        public virtual string RootUrl
        {
            get;
            set;
        }

        public virtual ReadOnlyCollection<ContentType> ContentTypes
        {
            get { return new ReadOnlyCollection<ContentType>(this.contentTypes); }
        }

        #endregion

        #region IEntityLifeCycle

        public virtual StatutLifeCycle LifeCycle
        {
            get;
            protected internal set;
        }

        public virtual void ApplyDefaultSettings()
        {
            EntityAssistant.ChangeActive(this, false);
            EntityAssistant.ChangeDeletable(this, true);
            EntityAssistant.ChangeEditable(this, true);
        }

        #endregion

        protected Application()
        {
            this.LifeCycle = StatutLifeCycle.Factory.Create();
            this.ApplyDefaultSettings();
        }
    }
}
