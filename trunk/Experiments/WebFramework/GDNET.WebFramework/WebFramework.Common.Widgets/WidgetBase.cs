using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using WebFramework.Common.Framework.System;
using WebFramework.Domain;
using WebFramework.Domain.Constants;
using WebFramework.Domain.System;

namespace WebFramework.Common.Widgets
{
    public abstract class WidgetBase<TResult> : AreaRegistration, IWidget
    {
        #region Members

        private const string DefaultTemplate = "Default";
        private IList<WidgetPropertyInfo> propertiesInfo = new List<WidgetPropertyInfo>();
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

        public virtual string UsageTemplate
        {
            get { return this.GetPropertyValue<string>(WidgetBaseConstants.PropertyUsageTemplate); }
        }

        public virtual string Version
        {
            get { return this.GetType().Assembly.GetName().Version.ToString(); }
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
                foreach (var propertyInfo in this.propertiesInfo)
                {
                    WidgetProperty widgetProperty = WidgetProperty.Factory.Create(propertyInfo.Code, propertyInfo.Value);
                    if (!string.IsNullOrEmpty(propertyInfo.DataTypeName))
                    {
                        widgetProperty.DataType = DomainRepositories.ListValue.FindByName(propertyInfo.DataTypeName);
                    }
                    widget.AddProperty(widgetProperty);
                }

                if (this.AfterInstalled != null)
                {
                    this.AfterInstalled(this, new WidgetEventArgs(widget));
                }

                DomainRepositories.RepositoryAssistant.Flush();
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
            this.BeforeInstalled += WidgetBeforeInstalled;
            this.AfterInstalled += WidgetAfterInstalled;
        }

        protected virtual void WidgetBeforeInstalled(object sender, EventArgs e)
        {
        }

        protected virtual void WidgetAfterInstalled(IWidget sender, WidgetEventArgs e)
        {
        }

        #endregion

        #region Behavior methods

        protected Widget GetWidgetInfo()
        {
            return DomainRepositories.Widget.GetByCode(this.Code);
        }

        /// <summary>
        /// Can be override in concrete implementation
        /// </summary>
        protected virtual void RegisterProperties()
        {
            // Based properties
            this.RegisterProperty(WidgetBaseConstants.PropertyUsageTemplate, DefaultTemplate, ListValueConstants.ContentDataTypes.TextSimpleTextBox);
        }

        protected void RegisterProperty(string code, string value)
        {
            RegisterProperty(code, value, string.Empty);
        }

        protected void RegisterProperty(string code, string value, string dataTypeCode)
        {
            if (this.propertiesInfo.Any(x => x.Code == code))
            {
            }
            else
            {
                this.propertiesInfo.Add(new WidgetPropertyInfo
                {
                    Code = code,
                    Value = value,
                    DataTypeName = dataTypeCode
                });
            }
        }

        protected T GetPropertyValue<T>(string propertyName)
        {
            if (this.region.Properties.Any(x => x.Key.Code == propertyName))
            {
                var kvp = this.region.Properties.First(x => x.Key.Code == propertyName);
                return (T)Convert.ChangeType(kvp.Value, typeof(T));
            }

            return default(T);
        }

        protected abstract TResult InitializeModel();

        #endregion

        #region AreaRegistration

        public override string AreaName
        {
            get { return this.TechnicalName; }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                string.Format("{0}_Default", this.AreaName),
                string.Format("Widget/{0}/{{controller}}/{{action}}/{{id}}", this.TechnicalName),
                new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                new string[] { string.Format("{0}.Controllers", this.GetType().Namespace) }
            );
        }

        #endregion
    }
}
