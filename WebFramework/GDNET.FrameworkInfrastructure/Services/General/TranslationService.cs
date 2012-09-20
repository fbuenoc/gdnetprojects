using System.Linq;
using System.Threading;
using GDNET.Domain.Repositories;
using log4net;

namespace GDNET.FrameworkInfrastructure.Services.General
{
    public sealed class TranslationService
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(TranslationService));

        public string GetByKeyword(string keyword)
        {
            string value = DomainRepositories.Translation.GetValueByKeyword(keyword, Thread.CurrentThread.CurrentUICulture);

            #region Debug
#if DEBUG
            if (string.IsNullOrEmpty(value))
            {
                logger.InfoFormat("{0} : {1}", Thread.CurrentThread.CurrentUICulture.Name, keyword);
                var listTranslations = DomainRepositories.Translation.GetAll().ToList();

                foreach (var aTranslation in listTranslations)
                {
                    logger.InfoFormat("Found {0} : {1} : {2}", Thread.CurrentThread.CurrentUICulture.Name, keyword, aTranslation.Value);
                }
            }
            else
            {
                logger.InfoFormat("Found {0} : {1} : {2}", Thread.CurrentThread.CurrentUICulture.Name, keyword, value);
            }
#endif
            #endregion

            return string.IsNullOrEmpty(value) ? string.Format("! {0} !", keyword) : value;
        }
    }
}
