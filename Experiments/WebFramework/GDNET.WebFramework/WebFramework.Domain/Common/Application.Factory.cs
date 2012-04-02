using GDNET.Common.DesignByContract;
using WebFramework.Domain.Constants;

namespace WebFramework.Domain.Common
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

            public Application Create(string name, string rootUrl)
            {
                return this.Create(name, rootUrl, ListValueConstants.ApplicationCategories.Default);
            }

            public Application Create(string name, string rootUrl, string categoryCode)
            {
                ThrowException.ArgumentExceptionIfNullOrEmpty(rootUrl, "rootUrl", "RootUrl can not be nullable.");

                Application application = new Application()
                {
                    RootUrl = rootUrl,
                    Name = Translation.Factory.Create(name),
                    Description = Translation.Factory.Create(string.Empty),
                    Category = DomainRepositories.ListValue.FindByName(categoryCode),
                };

                application.CultureDefault = DomainRepositories.Culture.FindByCode(CommonConstants.CultureCodeDefault);
                application.LifeCycle.AddStatutLog(StatutLog.Factory.Create(string.Empty));

                return application;
            }

        }
    }
}
