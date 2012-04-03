using WebFramework.Common.Framework.Base;
using WebFramework.Domain.System;

namespace WebFramework.Common.Framework.System
{
    public sealed class WidgetPropertyModel : ModelBase<WidgetProperty, long>
    {
        public string Code
        {
            get;
            set;
        }

        public string Value
        {
            get;
            set;
        }

        #region Ctors

        public WidgetPropertyModel()
            : base()
        {
        }

        public WidgetPropertyModel(WidgetProperty entity)
            : base(entity)
        {
            this.Code = entity.Code;
            this.Value = entity.Value;
        }

        #endregion
    }
}
