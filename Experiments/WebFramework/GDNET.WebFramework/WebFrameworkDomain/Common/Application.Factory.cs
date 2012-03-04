using GDNET.Common.DesignByContract;
using WebFrameworkDomain.Constants;
using WebFrameworkDomain.DefaultImpl;

namespace WebFrameworkDomain.Common
{
    public partial class Application
    {
        public static ApplicationFactory Factory
        {
            get { return new ApplicationFactory(); }
        }

        public class ApplicationFactory
        {
            public Application NewInstance()
            {
                return new Application();
            }

            public Application Create(string name, string description, string rootUrl)
            {
                return this.Create(name, description, rootUrl, ListValueConstants.ApplicationCategories.Default);
            }

            public Application Create(string name, string description, string rootUrl, string categoryCode)
            {
                ThrowException.ArgumentExceptionIfNullOrEmpty(rootUrl, "rootUrl", "RootUrl can not be nullable.");

                Application application = new Application
                {
                    RootUrl = rootUrl,
                };

                application.Name = Translation.Factory.Create(name);
                application.Description = Translation.Factory.Create(description);
                application.Category = DomainRepositories.ListValue.FindByName(categoryCode);
                application.CultureDefault = DomainRepositories.Culture.FindByCode(CommonConstants.CultureCodeDefault);
                application.LifeCycle.AddStatutLog(StatutLog.Factory.Create("BF"));

                return application;
            }

        }
    }
}
