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
                return new WidgetProperty()
                {
                    Code = code,
                    Value = value
                };
            }
        }
    }
}
