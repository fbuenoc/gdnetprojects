using GDNET.Web.Helpers;
using WebFramework.Domain;
using WebFramework.Domain.Common;
using WebFramework.Domain.Services;

namespace WebFramework.Services.Common
{
    public class WebSessionInformationService
    {
        #region Singleton

        private class Nested
        {
            public static readonly WebSessionInformationService Instance = new WebSessionInformationService();
        }

        public static WebSessionInformationService Instance
        {
            get { return Nested.Instance; }
        }

        #endregion

        public Application CurrentApplication
        {
            get;
            private set;
        }

        public Culture CurrentCulture
        {
            get;
            private set;
        }

        public void Initialize()
        {
            this.CurrentApplication = DomainRepositories.Application.GetByRootUrl(WebAssistant.GetCurrentDomain(), true);
            if (this.CurrentApplication != null)
            {
                this.CurrentCulture = this.CurrentApplication.CultureDefault;
            }
        }
    }
}
