using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using GDNET.Web.Helpers;
using WebFramework.Common.Framework.System;
using WebFramework.Domain;
using WebFramework.Domain.Constants;
using WebFramework.Domain.System;

namespace WebFramework.Common.Widgets
{
    public abstract class WidgetBase<TResult> : AreaRegistration, IWidget where TResult : WidgetModelBase
    {
        #region Members

        private const string DefaultTemplate = "Default";
        private IList<WidgetPropertyInfo> propertiesInfo = new List<WidgetPropertyInfo>();
        protected RegionModel regionModel = null;

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
            get
            {
                // Do nothing here
                return new List<WidgetAction>();
            }
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

        public object Initialize(RegionModel regionModel)
        {
            this.regionModel = regionModel;
            return this.InitializeModel();
        }

        public virtual string AdministerUrl
        {
            get
            {
                if (this.regionModel == null || this.regionModel.Zone == null)
                {
                    return string.Empty;
                }

                return string.Format("{0}/Widget/{1}/Admin?rid={2}&zid={3}", WebAssistant.GetCurrentDomain(), this.TechnicalName, this.regionModel.Id, this.regionModel.Zone.Id);
            }
        }

        public virtual string CurrentView
        {
            get { return "Index"; }
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
            // Do nothing here
        }

        protected virtual void WidgetAfterInstalled(IWidget sender, WidgetEventArgs e)
        {
            // Do nothing here
        }

        #endregion

        #region Behavior methods

        protected Widget GetWidgetInfo()
        {
            return DomainRepositories.Widget.GetByCode(this.Code);
        }

        protected Region GetCurrentRegion()
        {
            if (this.regionModel != null && this.regionModel.Zone != null)
            {
                var zone = DomainRepositories.Zone.GetById(this.regionModel.Zone.Id);
                return zone.GetRegionById(this.regionModel.Id);
            }

            return null;
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
            this.RegisterProperty(code, value, string.Empty);
        }

        protected void RegisterProperty(string code, string value, string dataTypeCode)
        {
            if (!this.propertiesInfo.Any(x => x.Code == code))
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
            if (this.regionModel.Properties.Any(x => x.Key.Code == propertyName))
            {
                var kvp = this.regionModel.Properties.First(x => x.Key.Code == propertyName);
                if (typeof(T).BaseType == typeof(Enum))
                {
                    return (T)Enum.Parse(typeof(T), kvp.Value);
                }
                else
                {
                    return (T)Convert.ChangeType(kvp.Value, typeof(T));
                }
            }

            return default(T);
        }

        protected virtual TResult InitializeModel()
        {
            TResult resultModel = (TResult)Activator.CreateInstance(typeof(TResult), this.regionModel);
            resultModel.AdministerUrl = this.AdministerUrl;

            return resultModel;
        }

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
