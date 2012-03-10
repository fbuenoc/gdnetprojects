using WebFramework.Business.Base;

namespace WebFramework.Business.Administration
{
    public sealed partial class Shortcut
    {
        public static ShortcutFactory Factory
        {
            get { return new ShortcutFactory(); }
        }

        public class ShortcutFactory
        {
            public Shortcut NewInstance()
            {
                return BusinessEntityBase.Factory.NewInstance<Shortcut>();
            }

            public Shortcut Create(string name, string description, string targetUrl)
            {
                var sh = BusinessEntityBase.Factory.Create<Shortcut>(name, description);
                sh.TargetUrl = targetUrl;

                return sh;
            }
        }
    }
}
