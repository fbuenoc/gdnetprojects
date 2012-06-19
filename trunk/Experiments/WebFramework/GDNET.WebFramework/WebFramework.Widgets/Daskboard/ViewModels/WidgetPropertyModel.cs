using WebFramework.Domain.System;
using WebFramework.Widgets.Daskboard.Base;

namespace WebFramework.Widgets.Daskboard.ViewModels
{
    public sealed class WidgetPropertyModel : ModelEntityBase<WidgetProperty, long>
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

        public ListValueModel DataType
        {
            get
            {
                if (base.Entity != null && base.Entity.DataType != null)
                {
                    return new ListValueModel(base.Entity.DataType);
                }
                return default(ListValueModel);
            }
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
