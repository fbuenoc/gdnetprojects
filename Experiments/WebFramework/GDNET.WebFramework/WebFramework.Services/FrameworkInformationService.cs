using GDNET.Web.Helpers;
using WebFramework.Domain;
using WebFramework.Domain.Common;

namespace WebFramework.Services
{
    public class FrameworkInformationService
    {
        #region Singleton

        private class Nested
        {
            public static readonly FrameworkInformationService Instance = new FrameworkInformationService();
        }

        public static FrameworkInformationService Instance
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
