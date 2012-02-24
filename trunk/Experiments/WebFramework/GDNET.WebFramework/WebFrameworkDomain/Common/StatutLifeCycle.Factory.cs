namespace WebFrameworkDomain.Common
{
    public partial class StatutLifeCycle
    {
        public static StatutLifeCycleFactory Factory
        {
            get { return new StatutLifeCycleFactory(); }
        }

        public class StatutLifeCycleFactory
        {
            public StatutLifeCycle Create()
            {
                return new StatutLifeCycle();
            }
        }

    }
}
