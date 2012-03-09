using GDNET.Common.Data;
using WebFrameworkDomain.Common;

namespace WebFrameworkDomain.Repositories.Common
{
    public interface ITranslationRepository : IRepositoryBase<Translation, long>
    {
        /// <summary>
        /// Get a translation by code
        /// </summary>
        Translation GetByCode(string code);
        Translation GetByCode(string code, Culture culture);
    }
}
