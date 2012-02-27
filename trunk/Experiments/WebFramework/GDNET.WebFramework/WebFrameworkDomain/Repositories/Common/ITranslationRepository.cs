using GDNET.Common.Data;
using WebFrameworkDomain.Common;

namespace WebFrameworkDomain.Repositories.Common
{
    public interface ITranslationRepository : IRepositoryBase<Translation, long>
    {
        /// <summary>
        /// Get a translation by code
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        Translation GetByCode(string code);
    }
}
