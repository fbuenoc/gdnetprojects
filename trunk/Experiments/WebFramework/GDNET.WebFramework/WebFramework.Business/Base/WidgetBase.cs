using System.Collections.Generic;

namespace WebFramework.Business.Base
{
    public abstract class WidgetBase
    {
        private Dictionary<string, string> propertiesInfo = new Dictionary<string, string>();

        public WidgetBase()
        {
            this.RegisterProperties();
        }

        /// <summary>
        /// Registered all properties for the widget
        /// </summary>
        protected abstract void RegisterProperties();

        /// <summary>
        /// The widget is initialize, displaying content
        /// </summary>
        public abstract void Initialize();

        protected void RegisterProperty(string code, string value)
        {
            propertiesInfo.Add(code, value);
        }
    }
}
