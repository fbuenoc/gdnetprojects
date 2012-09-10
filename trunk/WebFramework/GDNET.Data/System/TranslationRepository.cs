using System;
using GDNET.Domain.Entities.System;
using GDNET.Domain.Repositories.System;
using GDNET.NHibernate.Repositories;
using GDNET.NHibernate.SessionManagement;
using GDNET.Utils;

namespace GDNET.Data.System
{
    public class TranslationRepository : AbstractRepository<Translation, Guid>, ITranslationRepository
    {
        private const Translation DefaultTranslation = default(Translation);

        public TranslationRepository(INHibernateRepositoryStrategy strategy)
            : base(strategy)
        {
        }

        public Translation GetByKeyword(string keyword)
        {
            return base.GetByProperty(ExpressionAssistant.GetPropertyName(() => DefaultTranslation.Keyword), keyword);
        }
    }
}
