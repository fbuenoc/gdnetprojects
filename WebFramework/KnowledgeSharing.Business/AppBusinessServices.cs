using KnowledgeSharing.Business.Services;
using KnowledgeSharing.Domain;
using KnowledgeSharing.Domain.Services;

namespace KnowledgeSharing.Business
{
    public sealed class AppBusinessServices : AppDomainServices
    {
        public AppBusinessServices()
            : base()
        {
            base.Initialize(this);
        }

        protected override IContentBonusService GetContentBonusService()
        {
            return new ContentBonusService();
        }
    }
}
