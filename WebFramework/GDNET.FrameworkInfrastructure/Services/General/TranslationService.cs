using System.Threading;
using GDNET.Domain.Repositories;

namespace GDNET.FrameworkInfrastructure.Services.General
{
    public sealed class TranslationService
    {
        public string GetByKeyword(string keyword)
        {
            return DomainRepositories.Translation.GetValueByKeyword(keyword, Thread.CurrentThread.CurrentUICulture);
        }
    }
}
