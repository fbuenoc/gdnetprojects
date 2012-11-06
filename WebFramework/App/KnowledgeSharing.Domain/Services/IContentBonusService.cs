using GDNET.Domain.Entities.System;

namespace KnowledgeSharing.Domain.Services
{
    public interface IContentBonusService
    {
        void CalculateTotalPoints(User user);
    }
}
