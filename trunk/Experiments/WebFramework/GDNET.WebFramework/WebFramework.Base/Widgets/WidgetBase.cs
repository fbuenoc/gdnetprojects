using System;
using System.Collections.Generic;
using WebFramework.Domain;
using WebFramework.Domain.System;

namespace WebFramework.Base.Widgets
{
    public abstract class WidgetBase : IWidget
    {
        private Dictionary<string, string> propertiesInfo = new Dictionary<string, string>();

        public event EventHandler BeforeInstalled;
        public event WidgetEventHandler AfterInstalled;

        public abstract string Code
        {
            get;
        }

        public virtual string Version
        {
            get { return this.GetType().Assembly.GetName().Version.ToString(); }
        }

        public Dictionary<string, string> PropertiesInfo
        {
            get { return this.propertiesInfo; }
        }

        public bool Install()
        {
            if (this.BeforeInstalled != null)
            {
                this.BeforeInstalled(this, EventArgs.Empty);
            }

            Widget widget = Widget.Factory.Create(this.Code, this.GetType().Name);
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

        public bool Initialize()
        {
            return true;
        }

        public bool Uninstall()
        {
            return true;
        }

        public bool Display()
        {
            return true;
        }

        protected void RegisterProperty(string code, string value)
        {
            this.propertiesInfo.Add(code, value);
        }
    }
}
