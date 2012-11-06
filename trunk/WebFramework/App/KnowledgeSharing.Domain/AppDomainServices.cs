using KnowledgeSharing.Domain.Services;

namespace KnowledgeSharing.Domain
{
    public abstract class AppDomainServices
    {
        public static AppDomainServices _instance = null;

        public AppDomainServices()
        {
        }

        protected void Initialize(AppDomainServices instance)
        {
            _instance = instance;
        }

        public static IContentBonusService ContentBonus
        {
            get { return _instance.GetContentBonusService(); }
        }

        protected abstract IContentBonusService GetContentBonusService();
    }
}
