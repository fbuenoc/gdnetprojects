using WebFramework.Domain.Common;

namespace WebFramework.Domain.System
{
    public partial class WidgetProperty
    {
        public static WidgetPropertyFactory Factory
        {
            get { return new WidgetPropertyFactory(); }
        }

        public class WidgetPropertyFactory
        {
            public WidgetProperty Create(string code, string value)
            {
                var property = new WidgetProperty()
                {
                    Code = code,
                    Value = value
                };

                StatutLog statutLog = StatutLog.Factory.Create("Factory");
                property.LifeCycle.AddStatutLog(statutLog);

                return property;
            }
        }
    }
}
