using GDNET.Common.Data;

namespace WebFrameworkDomain.Common.Repositories
{
    public interface IRepositoryTranslation : IRepositoryBase<Translation, long>
    {
        /// <summary>
        /// Get a translation by code
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        Translation GetByCode(string code);
    }
}
