using System.Collections.Generic;
using System.Collections.ObjectModel;
using GDNET.Common.Base.Entities;
using WebFramework.Domain.Base;
using WebFramework.Domain.Common;

namespace WebFramework.Domain.System
{
    public partial class Widget : EntityWithActiveBase<long>, IEntityWithLifeCycle
    {
        #region Fields

        private IList<WidgetProperty> properties = new List<WidgetProperty>();

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
            protected internal set;
        }

        public virtual string TechnicalName
        {
            get;
            protected internal set;
        }

        public virtual string Version
        {
            get;
            set;
        }

        public virtual string ClassName
        {
            get;
            set;
        }

        public virtual string AssemblyName
        {
            get;
            set;
        }

        public virtual ReadOnlyCollection<WidgetProperty> Properties
        {
            get { return new ReadOnlyCollection<WidgetProperty>(this.properties); }
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

        #region Methods

        public virtual void AddProperty(WidgetProperty property)
        {
            if (!this.Properties.Contains(property))
            {
                property.Widget = this;
                this.properties.Add(property);
            }
        }

        public virtual void RemoveProperty(WidgetProperty property)
        {
            if (this.Properties.Contains(property))
            {
                this.properties.Remove(property);
            }
        }

        public virtual void RemoveAllProperties()
        {
            this.properties.Clear();
        }

        #endregion

        #region Ctors

        protected Widget()
        {
            this.LifeCycle = StatutLifeCycle.Factory.Create();
            this.ApplyDefaultSettings();
        }

        #endregion
    }
}
