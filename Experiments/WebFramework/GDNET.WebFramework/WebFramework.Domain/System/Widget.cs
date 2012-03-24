using System.Collections.Generic;
using System.Collections.ObjectModel;
using GDNET.Common.Base.Entities;
using WebFramework.Domain.Base;
using WebFramework.Domain.Common;

namespace WebFramework.Domain.System
{
    public partial class Widget : EntityBase<long>, IEntityWithLifeCycle
    {
        #region Fields

        private IList<WidgetFactory> widgetProperties = new List<WidgetFactory>();

        #endregion

        #region Properties

        public virtual Translation Name
        {
            get;
            protected internal set;
        }

        public virtual Translation Description
        {
            get;
            protected internal set;
        }

        public virtual string Code
        {
            get;
            set;
        }

        public virtual ReadOnlyCollection<WidgetFactory> Properties
        {
            get { return new ReadOnlyCollection<WidgetFactory>(this.widgetProperties); }
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

        #endregion

        #region Ctors

        protected Widget() { }

        #endregion
    }
}
