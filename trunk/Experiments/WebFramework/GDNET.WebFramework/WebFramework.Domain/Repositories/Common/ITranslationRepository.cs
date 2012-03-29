using GDNET.Common.Data;
using WebFramework.Domain.Common;

namespace WebFramework.Domain.Repositories.Common
{
    public interface ITranslationRepository : IRepositoryWithActiveBase<Translation, long>
    {
        /// <summary>
        /// Get a translation by code
        /// </summary>
        Translation GetByCode(string code);
        Translation GetByCode(string code, Culture culture);
    }
}
