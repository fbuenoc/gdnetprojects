using WebFramework.Common.Framework.Base;
using WebFramework.Domain.System;

namespace WebFramework.Common.Framework.System
{
    public sealed class WidgetModel : ModelWithActiveBase<Widget, long>
    {
        public string Code
        {
            get;
            set;
        }

        public string TechnicalName
        {
            get;
            set;
        }

        public string ClassName
        {
            get;
            set;
        }

        public string AssemblyName
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public string Description
        {
            get;
            set;
        }

        public string Version
        {
            get;
            set;
        }

        public WidgetModel()
            : base()
        {
        }

        public WidgetModel(Widget entity)
            : base(entity)
        {
            this.Code = entity.Code;
            this.TechnicalName = entity.TechnicalName;
            this.ClassName = entity.ClassName;
            this.AssemblyName = entity.AssemblyName;
            this.Version = entity.Version;
            this.Name = entity.Name.Value;
            this.Description = entity.Description.Value;
        }
    }
}
