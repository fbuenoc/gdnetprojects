using GDNET.Common.Base.Entities;
using GDNET.Common.DesignByContract;
using System;

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
            public Application Create()
            {
                return new Application
                {
                    IsActive = false,
                    IsDeletable = true,
                    IsEditable = true,
                    IsViewable = true,
                };
            }

            public Application Create(string rootUrl, string name, string description)
            {
                Throw.ArgumentExceptionIfNullOrEmpty(rootUrl, "rootUrl", "RootUrl can not be nullable.");

                var application = this.Create();

                application.RootUrl = rootUrl;
                application.Name = Translation.Factory.Create(Guid.NewGuid().ToString(), name);
                application.Description = Translation.Factory.Create(Guid.NewGuid().ToString(), description);

                return application;
            }
        }
    }
}
