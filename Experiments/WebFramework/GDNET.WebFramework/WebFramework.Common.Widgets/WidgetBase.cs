using System;
using System.Collections.Generic;
using System.Linq;
using WebFramework.Common.Framework.System;
using WebFramework.Domain;
using WebFramework.Domain.System;

namespace WebFramework.Common.Widgets
{
    public abstract class WidgetBase<TResult> : IWidget
    {
        #region Members

        private const string DefaultTemplate = "Default";
        private Dictionary<string, string> propertiesInfo = new Dictionary<string, string>();
        protected RegionModel region = null;

        #endregion

        #region Properties

        public abstract string Code
        {
            get;
        }

        public virtual string TechnicalName
        {
            get
            {
                // 6 = length of "Widget"
                return this.GetType().Name.Substring(0, this.GetType().Name.Length - 6);
            }
        }

        public virtual string Version
        {
            get { return this.GetType().Assembly.GetName().Version.ToString(); }
        }

        public Dictionary<string, string> PropertiesInfo
        {
            get { return this.propertiesInfo; }
        }

        public virtual IList<WidgetAction> Actions
        {
            get { return new List<WidgetAction>(); }
        }

        #endregion

        #region IWidget Members

        public event EventHandler BeforeInstalled;
        public event WidgetEventHandler AfterInstalled;

        public bool Install()
        {
            if (this.BeforeInstalled != null)
            {
                this.BeforeInstalled(this, EventArgs.Empty);
            }

            Widget widget = Widget.Factory.Create(this.Code, this.TechnicalName, this.GetType().Name);
            widget.ClassName = this.GetType().FullName;
            widget.AssemblyName = this.GetType().Assembly.GetName().Name;
            widget.Version = this.Version;

            var result = DomainRepositories.Widget.Save(widget);
            if (result)
            {
                foreach (var kvp in this.PropertiesInfo)
                {
                    WidgetProperty property = WidgetProperty.Factory.Create(kvp.Key, kvp.Value);
                    widget.AddProperty(property);
                }
                DomainRepositories.RepositoryAssistant.Flush();
            }

            if (this.AfterInstalled != null)
            {
                this.AfterInstalled(this, new WidgetEventArgs(widget));
            }

            return result;
        }

        public bool Uninstall()
        {
            return true;
        }

        public object Initialize(RegionModel region)
        {
            this.region = region;
            return this.InitializeModel();
        }

        #endregion

        #region Ctors

        public WidgetBase()
        {
            this.RegisterProperties();
        }

        #endregion

        #region Behavior methods

        /// <summary>
        /// Can be override in concrete implementation
        /// </summary>
        protected virtual void RegisterProperties()
        {
            // Based properties
            this.RegisterProperty(WidgetBaseConstants.PropertyUsageTemplate, DefaultTemplate);
        }

        protected void RegisterProperty(string code, string value)
        {
            this.propertiesInfo.Add(code, value);
        }

        protected T GetPropertyValue<T>(string propertyName)
        {
            if (this.region.Properties.Any(x => x.Key == propertyName))
            {
                var kvp = this.region.Properties.First(x => x.Key == propertyName);
                return (T)Convert.ChangeType(kvp.Value, typeof(T));
            }

            return default(T);
        }

        protected abstract TResult InitializeModel();

        #endregion
    }
}
